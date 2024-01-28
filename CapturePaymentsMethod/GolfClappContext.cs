using CapturePaymentsMethod.Entities;
using System.Data.Entity;
using System.Reflection.Emit;

namespace CapturePaymentsMethod
{
    public class YourDbContext : DbContext
    {
        public YourDbContext() : base("Data Source=localhost;Initial Catalog=GOLFCLAPP;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False")
        {
            // Constructor logic
            Database.SetInitializer<YourDbContext>(null);
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameUser> GameUsers{ get; set; }

        // Other DbSets and configurations as needed

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<GameUser>().ToTable("GameUser");
            // Other configurations if needed
        }


    }
}
