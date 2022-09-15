using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Data.CategoryRepository
{
    public interface ICategoryInterface
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int categoryID);
        Task<int> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(int categoryID);
    }
}