using Hexa.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hexa.Data.DataMapping.Customers
{
    public class TokenManagerMap : IEntityTypeConfiguration<TokenManager>
    {
        public void Configure(EntityTypeBuilder<TokenManager> builder)
        {
            builder.ToTable("TokenManager");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CreatedOn).HasDefaultValueSql("GETDATE()");
        }
    }
}
