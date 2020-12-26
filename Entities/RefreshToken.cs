using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPINetCore.Entities
{
    [Owned]
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public Account Account { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
        public string CreateByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokeByIp { get; set; }
        public string ReplaceByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
}
