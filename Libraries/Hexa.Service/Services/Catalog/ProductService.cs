using AutoMapper;
using Hexa.Business.Models.Catalog;
using Hexa.Core.Data;
using Hexa.Core.Domain.Catalog;
using Hexa.Service.Contracts.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hexa.Service.Services.Catalog
{
    public class ProductService : IProductService
    {
        #region Fields

        private readonly IHexaRepository<Product> _productRepository;
        private readonly IHexaRepository<ProductCategoryMapping> _productCategoryRepository;
        private readonly IHexaRepository<ProductPictureMapping> _productPictureMapping;

        #endregion

        #region Ctor

        public ProductService(IHexaRepository<Product> productRepository,
            IHexaRepository<ProductCategoryMapping> productCategoryRepository,
            IHexaRepository<ProductPictureMapping> productPictureMapping)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _productPictureMapping = productPictureMapping;
        }

        #endregion

        #region Product

        public void DeleteProduct(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("product");

            var product = GetProductById(id);
            product.Deleted = true;
            UpdateProduct(product);
        }

        public ProductModel GetProductById(int id)
        {
            if (id == 0)
                return null;

            var result = Mapper.Map<ProductModel>(_productRepository.GetById(id));
            return result;
        }

        public void InsertProduct(ProductModel product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            _productRepository.Insert(Mapper.Map<Product>(product));
        }

        public void UpdateProduct(ProductModel product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            _productRepository.Update(Mapper.Map<Product>(product));
        }

        public List<ProductModel> GetAllProducts(string name)
        {
            var query = _productRepository.Table;
            query = query.Where(c => c.Published);
            query = query.Where(c => !c.Deleted);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            return Mapper.Map<List<ProductModel>>(query.OrderBy(a => a.DisplayOrder).ToList());
        }

        #endregion

        #region Product Category Mapping

        public void DeleteProductCategoryMapping(ProductCategoryModel productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("ProductCategoryMapping");

            _productCategoryRepository.Delete(Mapper.Map<ProductCategoryMapping>(productCategory));
        }

        public void InsertProductCategoryMapping(ProductCategoryModel productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("ProductCategoryMapping");

            _productCategoryRepository.Insert(Mapper.Map<ProductCategoryMapping>(productCategory));
        }

        public void UpdateProductCategoryMapping(ProductCategoryModel productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("ProductCategoryMapping");

            _productCategoryRepository.Update(Mapper.Map<ProductCategoryMapping>(productCategory));
        }

        public List<ProductCategoryModel> GetProductCategoryMappingByProductId(int productId)
        {
            var query = _productCategoryRepository.Table.Where(a => a.ProductId == productId);
                        
            return Mapper.Map<List<ProductCategoryModel>>(query.OrderBy(a => a.DisplayOrder).ToList());
        }

        #endregion

        #region Product Picture Mapping

        public void DeleteProductPictureMapping(ProductPictureModel productPicture)
        {
            if (productPicture == null)
                throw new ArgumentNullException("ProductPictureModel");

            _productPictureMapping.Delete(Mapper.Map<ProductPictureMapping>(productPicture));
        }

        public void InsertProductPictureMapping(ProductPictureModel productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("ProductCategoryMapping");

            _productPictureMapping.Insert(Mapper.Map<ProductPictureMapping>(productCategory));
        }

        public void UpdateProductPictureMapping(ProductPictureModel productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("ProductCategoryMapping");

            _productPictureMapping.Update(Mapper.Map<ProductPictureMapping>(productCategory));
        }

        public List<ProductPictureModel> GetProductPictureMappingByProductId(int productId)
        {
            var query = _productPictureMapping.Table.Where(a => a.ProductId == productId);

            return Mapper.Map<List<ProductPictureModel>>(query.OrderBy(a => a.DisplayOrder).ToList());
        }

        #endregion
    }
}
