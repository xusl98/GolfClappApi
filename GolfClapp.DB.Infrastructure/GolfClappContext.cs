using GolfClapp.DB.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClapp.DB.Infrastructure
{
    public class GolfClappContext : DbContext
    {
        public GolfClappContext(DbContextOptions<GolfClappContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<LogEntity> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new LogMapping());
        }
    }
}
