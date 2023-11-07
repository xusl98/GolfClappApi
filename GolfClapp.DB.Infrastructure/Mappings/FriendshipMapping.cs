using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObjectsLibrary.Entities;


namespace GolfClapp.DB.Infrastructure.Mappings
{
    public class FriendshipMapping : IEntityTypeConfiguration<FriendshipEntity>
    {
        public void Configure(EntityTypeBuilder<FriendshipEntity> builder)
        {
            builder.ToTable("Friendship");
            builder.HasKey(pk => pk.Id);

            builder.HasOne(friendship => friendship.User1)
            .WithMany()
            .HasForeignKey(friendship => friendship.User1Id);


            builder.HasOne(friendship => friendship.User2)
            .WithMany()
            .HasForeignKey(friendship => friendship.User2Id);





        }
    }
}
