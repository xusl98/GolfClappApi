using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObjectsLibrary.Entities;


namespace GolfClapp.DB.Infrastructure.Mappings
{
    public class FriendshipRequestMapping : IEntityTypeConfiguration<FriendshipRequestEntity>
    {
        public void Configure(EntityTypeBuilder<FriendshipRequestEntity> builder)
        {
            builder.ToTable("FriendshipRequest");
            builder.HasKey(pk => pk.Id);

            builder.HasOne(request => request.Receiver)
            .WithMany()
            .HasForeignKey(request => request.ReceiverId);


            builder.HasOne(request => request.Sender)
            .WithMany()
            .HasForeignKey(request => request.SenderId);





        }
    }
}
