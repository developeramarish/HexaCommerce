using System;
using System.Threading.Tasks;
using Hexa.Business.Models.Catalog;
using Hexa.Service.Contracts.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace HexaCommerce.Api.Admin
{
    public class CategoryController : BaseAdminApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryService.GetAllCategories(null));
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _categoryService.GetCategoryById(id));
        }

        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoryModel model)
        {
            try
            {
                await _categoryService.InsertCategory(model);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        // PUT: api/Category/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CategoryModel model)
        {
            try
            {
                await _categoryService.UpdateCategory(model);
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
                await _categoryService.DeleteCategory(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
