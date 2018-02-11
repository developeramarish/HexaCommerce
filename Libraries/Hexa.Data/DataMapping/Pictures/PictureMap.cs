using Hexa.Core.Domain.Pictures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hexa.Data.DataMapping.Pictures
{
    public partial class PictureMap : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("Picture");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CreatedOn).HasDefaultValueSql("GETDATE()");
        }
    }
}
