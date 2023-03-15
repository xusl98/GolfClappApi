using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObjectsLibrary.Entities;


namespace GolfClapp.DB.Infrastructure.Mappings
{
    public class GameMapping : IEntityTypeConfiguration<GameEntity>
    {
        public void Configure(EntityTypeBuilder<GameEntity> builder)
        {
            builder.ToTable("Game");
            builder.HasKey(pk => pk.Id);


            builder.HasOne(g => g.Course)
                .HasForeignKey(fk => fk.CourseId);

            


        }
    }
}
