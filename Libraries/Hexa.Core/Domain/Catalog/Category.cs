using Hexa.Core.Domain.Shared;

namespace Hexa.Core.Domain.Catalog
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureId { get; set; }

        public int ParentCategoryId { get; set; }

        public bool IncludeInNavigation { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public int DisplayOrder { get; set; }        
    }
}
