using Hexa.Core.Data;
using Hexa.Core.Domain.Catalog;
using Hexa.Service.Contracts.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hexa.Service
{
    public class CategoryService : ICategoryService
    {
        #region Fields

        private readonly IHexaRepository<Category> _categoryRepository;

        #endregion

        #region Ctor

        #endregion

        #region Methods

        public CategoryService(IHexaRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void DeleteCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            category.Deleted = true;
            UpdateCategory(category);
        }

        public Category GetCategoryById(int categoryId)
        {
            if (categoryId == 0)
                return null;

            return _categoryRepository.GetById(categoryId);
        }

        public void InsertCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _categoryRepository.Insert(category);
        }

        public void UpdateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _categoryRepository.Update(category);
        }

        public IList<Category> GetAllCategories(string name)
        {
            var query = _categoryRepository.Table;
            query = query.Where(c => c.Active);
            query = query.Where(c => !c.Deleted);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            return query.OrderBy(a => a.DisplayOrder).ToList();
        }

        #endregion
    }
}
