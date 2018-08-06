using Hexa.Business.Models.Catalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hexa.Service.Contracts.Catalog
{
    public interface IProductService
    {
        #region Product

        Task DeleteProduct(int id);

        Task<ProductModel> GetProductById(int id);

        Task InsertProduct(ProductModel product);

        Task UpdateProduct(ProductModel product);

        Task<List<ProductModel>> GetAllProducts(string name);

        #endregion

        #region Product Category Mapping

        Task DeleteProductCategoryMapping(ProductCategoryModel productCategory);

        Task InsertProductCategoryMapping(ProductCategoryModel productCategory);

        Task UpdateProductCategoryMapping(ProductCategoryModel productCategory);

        Task<List<ProductCategoryModel>> GetProductCategoryMappingByProductId(int productId);

        #endregion

        #region Product Picture Mapping

        Task DeleteProductPictureMapping(ProductPictureModel productPicture);

        Task InsertProductPictureMapping(ProductPictureModel productCategory);

        Task UpdateProductPictureMapping(ProductPictureModel productCategory);

        Task<List<ProductPictureModel>> GetProductPictureMappingByProductId(int productId);

        #endregion
    }
}
