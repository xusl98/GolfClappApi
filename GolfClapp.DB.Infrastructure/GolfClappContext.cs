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
        public DbSet<AppIsBlockedEntity> AppIsBlocked { get; set; }
        public DbSet<FriendshipRequestEntity> FriendshipRequests { get; set; }
        public DbSet<FriendshipEntity> Friendships { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new LogMapping());
            modelBuilder.ApplyConfiguration(new ServiceProviderMapping());
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new GameMapping());
            modelBuilder.ApplyConfiguration(new GameUserMapping());
            modelBuilder.ApplyConfiguration(new AppIsBlockedMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new FriendshipRequestMapping());
            modelBuilder.ApplyConfiguration(new FriendshipMapping());
            modelBuilder.ApplyConfiguration(new PaymentMapping());

        }
    }
}
