using Hexa.Business.Models.Pictures;
using Hexa.Business.Models.Shared;
using System.Collections.Generic;

namespace Hexa.Business.Models.Catalog
{
    public class ProductModel : BaseModel
    {
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

        public string PictureThumbnailUrl { get; set; }

        public List<PictureModel> Pictures { get; set; }

        public List<ProductCategoryModel> ProductCategories { get; set; }
    }
}
