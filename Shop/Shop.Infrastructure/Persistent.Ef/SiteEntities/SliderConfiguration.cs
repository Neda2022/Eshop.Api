using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.SiteEntity;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities
{
    internal class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(b => b.Title)
               .HasMaxLength(120)
               .IsRequired();
            builder.Property(b => b.ImageName)
                .HasMaxLength(120)
                .IsRequired();
            builder.Property(b => b.Link)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}
