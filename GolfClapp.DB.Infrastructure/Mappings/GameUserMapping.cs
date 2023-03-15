using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObjectsLibrary.Entities;


namespace GolfClapp.DB.Infrastructure.Mappings
{
    public class GameUserMapping : IEntityTypeConfiguration<GameUserEntity>
    {
        public void Configure(EntityTypeBuilder<GameUserEntity> builder)
        {
            builder.ToTable("GameUser");
            builder.HasKey(pk => pk.Id);


            builder.HasOne(gu => gu.User)
                .HasForeignKey(fk => fk.UserId);

            builder.HasOne(gu => gu.Game)
                .WithOne(g => g.Course);
                .HasForeignKey(fk => fk.GameId)

            


        }
    }
}
