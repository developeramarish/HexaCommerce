using System;

namespace Hexa.Core.Domain.Shared
{
    public partial class BaseEntity
    {
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }
    }
}