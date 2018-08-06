using Hexa.Business.Models.Catalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hexa.Service.Contracts.Catalog
{
    public interface ICategoryService
    {
        Task DeleteCategory(int id);

        Task<CategoryModel> GetCategoryById(int categoryId);

        Task InsertCategory(CategoryModel category);

        Task UpdateCategory(CategoryModel category);

        Task<List<CategoryModel>> GetAllCategories(string name);
    }
}
