using AutoMapper;
using Hexa.Business.Models.Catalog;
using Hexa.Core.Data;
using Hexa.Core.Domain.Catalog;
using Hexa.Service.Contracts.Catalog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hexa.Service.Services.Catalog
{
    public class ProductService : IProductService
    {
        #region Fields

        private readonly IHexaRepository<Product> _productRepository;
        private readonly IHexaRepository<ProductCategoryMapping> _productCategoryRepository;
        private readonly IHexaRepository<ProductPictureMapping> _productPictureMapping;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public ProductService(IHexaRepository<Product> productRepository,
            IHexaRepository<ProductCategoryMapping> productCategoryRepository,
            IHexaRepository<ProductPictureMapping> productPictureMapping,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _productPictureMapping = productPictureMapping;
            _mapper = mapper;
        }

        #endregion

        #region Product

        public async Task DeleteProduct(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("product");

            var product = await GetProductById(id);
            product.Deleted = true;
            await UpdateProduct(product);
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            if (id == 0)
                return null;

            return _mapper.Map<ProductModel>(await _productRepository.GetById(id));
        }

        public async Task InsertProduct(ProductModel product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            await _productRepository.Insert(_mapper.Map<Product>(product));
        }

        public async Task UpdateProduct(ProductModel product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            await _productRepository.Update(_mapper.Map<Product>(product));
        }

        public async Task<List<ProductModel>> GetAllProducts(string name)
        {
            var query = _productRepository.Table;
            query = query.Where(c => c.Published);
            query = query.Where(c => !c.Deleted);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            return _mapper.Map<List<ProductModel>>(await query.OrderBy(a => a.DisplayOrder).ToListAsync());
        }

        #endregion

        #region Product Category Mapping

        public async Task DeleteProductCategoryMapping(ProductCategoryModel productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("ProductCategoryMapping");

            await _productCategoryRepository.Delete(_mapper.Map<ProductCategoryMapping>(productCategory));
        }

        public async Task InsertProductCategoryMapping(ProductCategoryModel productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("ProductCategoryMapping");

            await _productCategoryRepository.Insert(_mapper.Map<ProductCategoryMapping>(productCategory));
        }

        public async Task UpdateProductCategoryMapping(ProductCategoryModel productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("ProductCategoryMapping");

            await _productCategoryRepository.Update(_mapper.Map<ProductCategoryMapping>(productCategory));
        }

        public async Task<List<ProductCategoryModel>> GetProductCategoryMappingByProductId(int productId)
        {
            var query = _productCategoryRepository.Table.Where(a => a.ProductId == productId);
                        
            return _mapper.Map<List<ProductCategoryModel>>(await query.OrderBy(a => a.DisplayOrder).ToListAsync());
        }

        #endregion

        #region Product Picture Mapping

        public async Task DeleteProductPictureMapping(ProductPictureModel productPicture)
        {
            if (productPicture == null)
                throw new ArgumentNullException("ProductPictureModel");

            await _productPictureMapping.Delete(_mapper.Map<ProductPictureMapping>(productPicture));
        }

        public async Task InsertProductPictureMapping(ProductPictureModel productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("ProductCategoryMapping");

            await _productPictureMapping.Insert(_mapper.Map<ProductPictureMapping>(productCategory));
        }

        public async Task UpdateProductPictureMapping(ProductPictureModel productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("ProductCategoryMapping");

            await _productPictureMapping.Update(_mapper.Map<ProductPictureMapping>(productCategory));
        }

        public async Task<List<ProductPictureModel>> GetProductPictureMappingByProductId(int productId)
        {
            var query = _productPictureMapping.Table.Where(a => a.ProductId == productId);

            return _mapper.Map<List<ProductPictureModel>>(await query.OrderBy(a => a.DisplayOrder).ToListAsync());
        }

        #endregion
    }
}
