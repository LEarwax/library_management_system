using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Data.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIDAsync(int categoryID)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryID == categoryID);
        }

        public async Task<int> AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.CategoryID;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var dbCategory = await _context.Categories.FirstAsync(c => c.CategoryID == category.CategoryID);
            dbCategory.CategoryName = category.CategoryName;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategoryAsync(int categoryID)
        {
            var dbCategory = await _context.Categories.FirstAsync(c => c.CategoryID == categoryID);
            _context.Categories.Remove(dbCategory);
            await _context.SaveChangesAsync();
        }
    }
}