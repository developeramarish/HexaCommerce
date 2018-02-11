using Hexa.Core.Domain.Shared;

namespace Hexa.Core.Domain.Catalog
{
    public class ProductPictureMapping : BaseEntity
    {
        public int PictureId { get; set; }

        public int ProductId { get; set; }

        public int DisplayOrder { get; set; }
    }
}
