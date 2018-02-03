using System;
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
        public IActionResult Get()
        {
            return Ok(_categoryService.GetAllCategories(null));
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_categoryService.GetCategoryById(id));
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult Post([FromBody]CategoryModel model)
        {
            try
            {
                _categoryService.InsertCategory(model);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        // PUT: api/Category/5
        [HttpPut]
        public IActionResult Put([FromBody]CategoryModel model)
        {
            try
            {
                _categoryService.UpdateCategory(model);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete([FromBody]CategoryModel model)
        {
            try
            {
                _categoryService.DeleteCategory(model);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
