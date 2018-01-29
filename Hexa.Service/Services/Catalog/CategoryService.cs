using AutoMapper;
using Hexa.Business.Models.Catalog;
using Hexa.Core.Data;
using Hexa.Core.Domain.Catalog;
using Hexa.Service.Contracts.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hexa.Service.Services.Catalog
{
    public class CategoryService : ICategoryService
    {
        #region Fields

        private readonly IHexaRepository<Category> _categoryRepository;

        #endregion

        #region Ctor

        public CategoryService(IHexaRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #endregion

        #region Methods

        public void DeleteCategory(CategoryModel category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            category.Deleted = true;
            UpdateCategory(category);
        }

        public CategoryModel GetCategoryById(int categoryId)
        {
            if (categoryId == 0)
                return null;

            return Mapper.Map<CategoryModel>(_categoryRepository.GetById(categoryId));
        }

        public void InsertCategory(CategoryModel category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _categoryRepository.Insert(Mapper.Map<Category>(category));
        }

        public void UpdateCategory(CategoryModel category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _categoryRepository.Update(Mapper.Map<Category>(category));
        }

        public List<CategoryModel> GetAllCategories(string name)
        {
            var query = _categoryRepository.Table;
            query = query.Where(c => c.Active);
            query = query.Where(c => !c.Deleted);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            return Mapper.Map<List<CategoryModel>>(query.OrderBy(a => a.DisplayOrder).ToList());
        }

        #endregion
    }
}
