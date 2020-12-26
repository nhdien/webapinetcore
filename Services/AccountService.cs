using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using BC = BCrypt.Net.BCrypt;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPINetCore.Helpers;
using WebAPINetCore.ModelContexts;
using WebAPINetCore.Models;
using WebAPINetCore.Entities;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Primitives;

namespace WebAPINetCore.Services
{
    public interface IAccountService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        void RevokeToken(string token, string ipAddress);
        void Register(RegisterRequest model, string origin);
        void VerifyEmail(string token);
        void ForgotPassword(ForgotPasswordRequest model, string origin);
        void ValidateResetToken(ValidateResetTokenRequest model);
        void ResetPassword(ResetPasswordRequest model);
        void ChangePassword(ChangePasswordRequest model);
    }
    public class AccountService : IAccountService
    {
        private readonly AuthContext _authContext;
        private readonly IMapper _mapper;
        private AppSettings _appSettings;

        public AccountService(
            AuthContext authContext,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _authContext = authContext;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress)
        {
            var account = _authContext.Accounts.SingleOrDefault(x => x.Email == model.Email);

            if (
                account == null ||
                !account.IsVerified ||
                !BC.Verify(model.Password, account.PasswordHash))
            {
                throw new AppException("Email or password is incorrect!");
            }

            var jwtToken = generateJwtToken(account);
            var refreshToken = generateRefreshToken(ipAddress);

            account.RefreshTokens.Add(refreshToken);

            removeOldRefreshToken(account);

            _authContext.Update(account);
            _authContext.SaveChanges();

            var response = _mapper.Map<AuthenticateResponse>(account);
            
            response.JwtToken = jwtToken;
            response.RefreshToken = refreshToken.Token;

            return response;
        }

        public void RevokeToken(string token, string ipAddress)
        {
            var (refreshToken, account) = getRefreshToken(token);

            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokeByIp = ipAddress;

            _authContext.Update(account);
            _authContext.SaveChanges();
        }

        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
            var (refreshToken, account) = getRefreshToken(token);


            var newRefreshToken = generateRefreshToken(ipAddress);

            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokeByIp = ipAddress;
            refreshToken.ReplaceByToken = newRefreshToken.Token;

            account.RefreshTokens.Add(newRefreshToken);

            removeOldRefreshToken(account);

            _authContext.Update(account);
            _authContext.SaveChanges();

            var jwtToken = generateJwtToken(account);

            var response = _mapper.Map<AuthenticateResponse>(account);
            response.JwtToken = jwtToken;
            response.RefreshToken = newRefreshToken.Token;

            return response;

        }

        public void VerifyEmail(string token)
        {
            var account = _authContext.Accounts.SingleOrDefault(x => x.VerificationToken == token);
            
            if (account == null)
            {
                throw new AppException("Verification failed!");
            }

            account.Verified = DateTime.UtcNow;
            account.VerificationToken = null;

            _authContext.Accounts.Update(account);
            _authContext.SaveChanges();
        }

        public void Register(RegisterRequest model, string origin)
        {
            if (_authContext.Accounts.Any(x => x.Email == model.Email))
            {
                throw new AppException("Email already registered!");
            }

            var account = _mapper.Map<Account>(model);
            var isFirstAccount = _authContext.Accounts.Count() == 0;

            account.Created = DateTime.UtcNow;
            account.VerificationToken = randomTokenString();

            account.PasswordHash = BC.HashPassword(model.Password);

            _authContext.Accounts.Add(account);
            _authContext.SaveChanges();
        }

        public void ForgotPassword(ForgotPasswordRequest model, string orgigin)
        {
            var account = _authContext.Accounts.SingleOrDefault(x => x.Email == model.Email);

            if (account == null)
            {
                return;
            }

            account.ResetToken = randomTokenString();
            account.ResetTokenExpires = DateTime.UtcNow.AddDays(1);

            _authContext.Accounts.Update(account);
            _authContext.SaveChanges();
        }

        public void ValidateResetToken(ValidateResetTokenRequest model)
        {
            var account = _authContext.Accounts.SingleOrDefault( x =>
                    x.ResetToken == model.Token &&
                    x.ResetTokenExpires > DateTime.UtcNow
                );

            if (account == null)
            {
                throw new AppException("Invalid token!");
            }
        }

        public void ResetPassword(ResetPasswordRequest model)
        {
            var account = _authContext.Accounts.SingleOrDefault(x =>
                   x.ResetToken == model.Token &&
                   x.ResetTokenExpires > DateTime.UtcNow);

            if (account == null)
            {
                throw new AppException("Invalid token!");
            }

            account.PasswordHash = BC.HashPassword(model.Password);
            account.PasswordReset = DateTime.UtcNow;
            account.ResetToken = null;
            account.ResetTokenExpires = null;

            _authContext.Accounts.Update(account);
            _authContext.SaveChanges();
        }

        public void ChangePassword(ChangePasswordRequest model)
        {
            var account = _authContext.Accounts.SingleOrDefault(x => x.Email == model.Email);

            if (account == null)
            {
                throw new AppException("Invalid email!");
            }

            account.PasswordHash = BC.HashPassword(model.Password);
            account.Updated = DateTime.UtcNow;

            _authContext.Accounts.Update(account);
            _authContext.SaveChanges();
        }

        /*
         * *******************************************************************************************
         * *******************************************************************************************
         */
        private void removeOldRefreshToken(Account account)
        {
            account.RefreshTokens.RemoveAll(x => !x.IsActive && x.Created.AddDays(_appSettings.RefreshTokenTimeToLive) <= DateTime.UtcNow);
        }

        private RefreshToken generateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = randomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreateByIp = ipAddress
            };
        }

        private string randomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();

            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);

            return BitConverter.ToString(randomBytes).Replace("-", "");
        }

        private string generateJwtToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", account.Id.ToString() ) }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }

        private (RefreshToken, Account) getRefreshToken(string token)
        {
            var account = _authContext.Accounts.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

            if (account == null)
            {
                throw new AppException("Invalid token");
            }

            var refreshToken = account.RefreshTokens.Single(x => x.Token == token);

            if (!refreshToken.IsActive)
            {
                throw new AppException("Invalid token");
            }

            return (refreshToken, account);
        }

        
    }
}
