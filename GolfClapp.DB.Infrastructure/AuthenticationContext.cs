using GolfClapp.DB.Infrastructure.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClapp.DB.Infrastructure
{
    public class AuthenticationContext : IdentityDbContext<UserEntity, IdentityRole<Guid>, Guid>
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMapping());
            
        }
    }
}
