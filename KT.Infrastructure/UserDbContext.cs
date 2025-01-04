using KT.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT.Infrastructure
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Otp> Otps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
        }
    }
}
