using Happy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Happy.Infra.Mappings
{
    internal class OrphanageMapConfig : IEntityTypeConfiguration<Orphanage>
    {
        public void Configure(EntityTypeBuilder<Orphanage> builder)
        {
            builder.ToTable("Orphanages");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(true)
                .HasColumnName("Name");

            builder.Property(c => c.About)
                .HasMaxLength(2048)
                .IsUnicode(true)
                .HasColumnName("About");

            builder.Property(c => c.Instructions)
                .HasMaxLength(2048)
                .IsUnicode(true)
                .HasColumnName("Instructions");

            builder.Property(c => c.OpeningHours)
               .HasMaxLength(64)
               .IsUnicode(true)
               .HasColumnName("OpeningHours");

            builder.Property(c => c.Latitude)
                .IsRequired()
                .HasColumnName("Latitude");

            builder.Property(c => c.Longitude)
              .IsRequired()
              .HasColumnName("Logitude");
        }
    }
}
