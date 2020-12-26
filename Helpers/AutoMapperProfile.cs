using AutoMapper;
using WebAPINetCore.Entities;
using WebAPINetCore.Models;

namespace WebAPINetCore.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountResponse>();
            CreateMap<Account, AuthenticateResponse>();
            CreateMap<RegisterRequest, Account>();
        }
    }
}
