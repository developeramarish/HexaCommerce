using Hexa.Core.Domain.Shared;

namespace Hexa.Core.Domain.Catalog
{
    public class ProductCategoryMapping : BaseEntity
    {
        public int CategoryId { get; set; }

        public int ProductId { get; set; }

        public int DisplayOrder { get; set; }
    }
}
