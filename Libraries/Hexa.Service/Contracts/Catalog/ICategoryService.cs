using Hexa.Business.Models.Catalog;
using System.Collections.Generic;

namespace Hexa.Service.Contracts.Catalog
{
    public interface ICategoryService
    {
        void DeleteCategory(CategoryModel category);

        CategoryModel GetCategoryById(int categoryId);

        void InsertCategory(CategoryModel category);

        void UpdateCategory(CategoryModel category);

        List<CategoryModel> GetAllCategories(string name);
    }
}
