using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObjectsLibrary.Entities;


namespace GolfClapp.DB.Infrastructure.Mappings
{
    public class LogMapping : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.ToTable("Log");
            builder.HasKey(pk => pk.Id);

            
        }
    }
}
