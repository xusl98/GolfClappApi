using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObjectsLibrary.Entities;


namespace GolfClapp.DB.Infrastructure.Mappings
{
    public class PaymentMapping : IEntityTypeConfiguration<PaymentEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            builder.ToTable("Payment");
            builder.HasKey(pk => pk.Id);


           

            


        }
    }
}
