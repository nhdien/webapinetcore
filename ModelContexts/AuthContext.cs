using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.EntityFrameworkCore;
using WebAPINetCore.Entities;

namespace WebAPINetCore.ModelContexts
{
    public class AuthContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AuthContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(
                _configuration.GetConnectionString("WebAPIAuthDatabase")
                );
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<DMTINH> DMTINH { get; set; }
        public DbSet<DMHUYEN> DMHUYEN { get; set; }
        public DbSet<DMPHUONGXA> DMPHUONGXA { get; set; }
        public DbSet<DMDANTOC> DMDANTOC { get; set; }
        public DbSet<DMTONGIAO> DMTONGIAO { get; set; }
        public DbSet<DMQUANHE> DMQUANHE { get; set; }
        public DbSet<DMHOCVAN> DMHOCVAN { get; set; }
        public DbSet<DMCAPBAC> DMCAPBAC { get; set; }
        public DbSet<DMLOAI_BANGKHEN> DMLOAI_BANGKHEN { get; set; }
        public DbSet<DMHUANHUYCHUONG> DMHUANHUYCHUONG { get; set; }
        public DbSet<DMDANHHIEU> DMDANHHIEU { get; set; }
    }
}
