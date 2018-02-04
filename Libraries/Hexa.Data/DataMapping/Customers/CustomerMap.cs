using Hexa.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hexa.Data.DataMapping.Customers
{
    public partial class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.UserName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Password).IsRequired().HasMaxLength(100);
            builder.Property(c => c.CreatedOn).HasDefaultValueSql("GETDATE()");
        }
    }
}
