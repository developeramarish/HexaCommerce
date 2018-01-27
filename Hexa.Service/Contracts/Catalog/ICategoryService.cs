using Hexa.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexa.Service.Contracts.Catalog
{
    public interface ICategoryService
    {
        void DeleteCategory(Category category);

        Category GetCategoryById(int categoryId);

        void InsertCategory(Category category);

        void UpdateCategory(Category category);

        IList<Category> GetAllCategories(string name);
    }
}
