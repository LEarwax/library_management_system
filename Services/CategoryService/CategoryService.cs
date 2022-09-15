using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using library_management_system.Data.CategoryRepository;
using library_management_system.Dtos.Category;

namespace library_management_system.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        
        public async Task<ServiceResponse<List<GetCategoryDto>>> GetCategoriesAsync()
        {
            ServiceResponse<List<GetCategoryDto>> response = new ServiceResponse<List<GetCategoryDto>>();

            try
            {
                var dbCategories = await _categoryRepo.GetCategoriesAsync();
                response.Data = dbCategories.Select(c => _mapper.Map<GetCategoryDto>(c)).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.StackTrace = ex.StackTrace;                
            }

            return response;
        }

        public async Task<ServiceResponse<GetCategoryDto>> GetCategoryByIDAsync(int categoryID)
        {
            ServiceResponse<GetCategoryDto> response = new ServiceResponse<GetCategoryDto>();

            try
            {
                var dbCategory = await _categoryRepo.GetCategoryByIDAsync(categoryID);
                response.Data = _mapper.Map<GetCategoryDto>(dbCategory);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.StackTrace = ex.StackTrace;                
            }

            return response;
        }
        
        public async Task<ServiceResponse<object>> AddCategoryAsync(AddCategoryDto addCategoryDto)
        {
            ServiceResponse<object> response = new ServiceResponse<object>();

            try
            {
                var categoryID = await _categoryRepo.AddCategoryAsync(_mapper.Map<Category>(addCategoryDto));
                response.Data = new { CategoryID = categoryID };
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.StackTrace = ex.StackTrace;                
            }

            return response;
        }

        public async Task<ServiceResponse<GetCategoryDto>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            ServiceResponse<GetCategoryDto> response = new ServiceResponse<GetCategoryDto>();
            
            try
            {
                var dbBook = await _categoryRepo.UpdateCategoryAsync(_mapper.Map<Category>(updateCategoryDto));
                response.Data = _mapper.Map<GetCategoryDto>(dbBook);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.StackTrace = ex.StackTrace;
            }

            return response;
        }

        public async Task<ServiceResponse<string>> DeleteCategoryAsync(int categoryID)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            
            try
            {
                await _categoryRepo.DeleteCategoryAsync(categoryID);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.StackTrace = ex.StackTrace;
            }

            return response;
        }
    }
}