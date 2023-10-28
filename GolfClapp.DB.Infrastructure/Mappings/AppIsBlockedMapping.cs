using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObjectsLibrary.Entities;


namespace GolfClapp.DB.Infrastructure.Mappings
{
    public class AppIsBlockedMapping : IEntityTypeConfiguration<AppIsBlockedEntity>
    {
        public void Configure(EntityTypeBuilder<AppIsBlockedEntity> builder)
        {
            builder.ToTable("AppIsBlocked");            
            builder.HasNoKey();
            

            



        }
    }
}
