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

        
        public DbSet<LogEntity> Logs { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<ServiceProviderEntity> ServiceProviders { get; set; }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<GameUserEntity> GameUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new LogMapping());
            modelBuilder.ApplyConfiguration(new ServiceProviderMapping());
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new GameMapping());
            modelBuilder.ApplyConfiguration(new GameUserMapping());

        }
    }
}
