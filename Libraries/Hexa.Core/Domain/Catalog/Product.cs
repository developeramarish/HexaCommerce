using Hexa.Core.Domain.Shared;
using System.Collections.Generic;

namespace Hexa.Core.Domain.Catalog
{
    public class Product : BaseEntity
    {
        private ICollection<ProductCategoryMapping> _productCategories;

        private ICollection<ProductPictureMapping> _productPictures;

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public string AdminComment { get; set; }

        public bool ShowOnHomePage { get; set; }

        public bool AllowCustomerReviews { get; set; }

        public string Sku { get; set; }

        public string ManufacturerPartNumber { get; set; }

        public string Gtin { get; set; }

        public bool IsShipEnabled { get; set; }

        public bool IsFreeShipping { get; set; }

        public bool IsTaxExempt { get; set; }

        public int TaxCategoryId { get; set; }

        public int StockQuantity { get; set; }

        public bool DisplayStockAvailability { get; set; }

        public bool DisplayStockQuantity { get; set; }

        public int MinStockQuantity { get; set; }

        public int OrderMinimumQuantity { get; set; }

        public int OrderMaximumQuantity { get; set; }

        public string AllowedQuantities { get; set; }

        public bool DisableBuyButton { get; set; }

        public decimal Price { get; set; }

        public decimal OldPrice { get; set; }

        public decimal ProductCost { get; set; }

        public bool MarkAsNew { get; set; }

        public decimal Weight { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public int DisplayOrder { get; set; }

        public bool Published { get; set; }

        public bool Deleted { get; set; }

        public virtual ICollection<ProductCategoryMapping> ProductCategories
        {
            get { return _productCategories ?? (_productCategories = new List<ProductCategoryMapping>()); }
            protected set { _productCategories = value; }
        }

        public virtual ICollection<ProductPictureMapping> ProductPictures
        {
            get { return _productPictures ?? (_productPictures = new List<ProductPictureMapping>()); }
            protected set { _productPictures = value; }
        }
    }
}
