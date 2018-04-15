using Hexa.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hexa.Data.DataMapping.Catalog
{
    public partial class ProductCategoryMap : IEntityTypeConfiguration<ProductCategoryMapping>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryMapping> builder)
        {
            builder.ToTable("ProductCategoryMapping");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CreatedOn).HasDefaultValueSql("GETDATE()");
        }
    }
}
