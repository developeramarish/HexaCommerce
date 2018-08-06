using System;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Get()
        {
            return Ok(await _productService.GetAllProducts(null));
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }
        
        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductModel model)
        {
            try
            {
                await _productService.InsertProduct(model);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Product/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ProductModel model)
        {
            try
            {
                await _productService.UpdateProduct(model);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteProduct(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
