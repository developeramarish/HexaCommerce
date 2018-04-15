using Hexa.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hexa.Data.DataMapping.Catalog
{
    public partial class ProductPictureMap : IEntityTypeConfiguration<ProductPictureMapping>
    {
        public void Configure(EntityTypeBuilder<ProductPictureMapping> builder)
        {
            builder.ToTable("ProductPictureMapping");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CreatedOn).HasDefaultValueSql("GETDATE()");
        }
    }
}
