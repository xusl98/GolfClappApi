using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObjectsLibrary.Entities;


namespace GolfClapp.DB.Infrastructure.Mappings
{
    public class ServiceProviderMapping : IEntityTypeConfiguration<ServiceProviderEntity>
    {
        public void Configure(EntityTypeBuilder<ServiceProviderEntity> builder)
        {
            builder.ToTable("ServiceProvider");
            builder.HasKey(pk => pk.Id);

            


        }
    }
}
