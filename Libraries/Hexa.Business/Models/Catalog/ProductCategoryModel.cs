using Hexa.Business.Models.Shared;

namespace Hexa.Business.Models.Catalog
{
    public class ProductCategoryModel : BaseModel
    {
        public int CategoryId { get; set; }

        public int ProductId { get; set; }

        public int DisplayOrder { get; set; }
    }
}