using Hexa.Core.Domain.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hexa.Data.DataMapping.Logs
{
    public partial class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Log");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CreatedOn).HasDefaultValueSql("GETDATE()");
        }
    }
}
