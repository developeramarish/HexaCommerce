using Hexa.Business.Models.Shared;

namespace Hexa.Business.Models.Catalog
{
    public class ProductPictureModel : BaseModel
    {
        public int PictureId { get; set; }

        public int ProductId { get; set; }

        public int DisplayOrder { get; set; }
    }
}