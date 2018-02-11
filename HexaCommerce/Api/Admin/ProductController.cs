using System;
using Hexa.Business.Models.Catalog;
using Hexa.Service.Contracts.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace HexaCommerce.Api.Admin
{
    public class ProductController : BaseAdminApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.GetAllProducts(null));
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_productService.GetProductById(id));
        }
        
        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody]ProductModel model)
        {
            try
            {
                _productService.InsertProduct(model);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Product/5
        [HttpPut]
        public IActionResult Put([FromBody]ProductModel model)
        {
            try
            {
                _productService.UpdateProduct(model);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
