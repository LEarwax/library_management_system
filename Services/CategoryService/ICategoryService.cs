using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_management_system.Dtos.Category;

namespace library_management_system.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<GetCategoryDto>>> GetCategoriesAsync();
        Task<ServiceResponse<GetCategoryDto>> GetCategoryByIDAsync(int categoryID);
        Task<ServiceResponse<object>> AddCategoryAsync(AddCategoryDto addCategoryDto);
        Task<ServiceResponse<GetCategoryDto>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<ServiceResponse<string>> DeleteCategoryAsync(int categoryID);
    }
}