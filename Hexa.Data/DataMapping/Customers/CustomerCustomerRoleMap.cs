using Hexa.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hexa.Data.DataMapping.Customers
{
    public partial class CustomerMap : IEntityTypeConfiguration<CustomerCustomerRole>
    {
        public void Configure(EntityTypeBuilder<CustomerCustomerRole> builder)
        {
            builder.ToTable("CustomerCustomerRole");

            builder.HasKey(c => c.Id);

            builder.HasKey(b => b.Id);

            builder.HasKey(b => new { b.CustomerId, b.CustomerRoleId });

            builder.HasOne(b => b.Customer).WithMany(b => b.CustomerRoles).HasForeignKey(b => b.CustomerId);

            builder.HasOne(b => b.CustomerRole).WithMany(b => b.CustomerRoles).HasForeignKey(b => b.CustomerRoleId);

            builder.Property(c => c.CreatedOn).HasDefaultValueSql("GETDATE()");
        }
    }
}
