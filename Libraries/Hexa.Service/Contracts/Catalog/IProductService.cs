using Hexa.Business.Models.Catalog;
using System.Collections.Generic;

namespace Hexa.Service.Contracts.Catalog
{
    public interface IProductService
    {
        #region Product

        void DeleteProduct(int id);

        ProductModel GetProductById(int id);

        void InsertProduct(ProductModel product);

        void UpdateProduct(ProductModel product);

        List<ProductModel> GetAllProducts(string name);

        #endregion

        #region Product Category Mapping

        void DeleteProductCategoryMapping(ProductCategoryModel productCategory);

        void InsertProductCategoryMapping(ProductCategoryModel productCategory);

        void UpdateProductCategoryMapping(ProductCategoryModel productCategory);

        List<ProductCategoryModel> GetProductCategoryMappingByProductId(int productId);

        #endregion

        #region Product Picture Mapping

        void DeleteProductPictureMapping(ProductPictureModel productPicture);

        void InsertProductPictureMapping(ProductPictureModel productCategory);

        void UpdateProductPictureMapping(ProductPictureModel productCategory);

        List<ProductPictureModel> GetProductPictureMappingByProductId(int productId);

        #endregion
    }
}
