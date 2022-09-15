using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using library_management_system.Data;
using library_management_system.Data.AuthorRepository;
using library_management_system.Dtos.Book.Author;

namespace library_management_system.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _autherRepo;
        public AuthorService(IMapper mapper, IAuthorRepository authorRepo)
        {
            _mapper = mapper;
            _autherRepo = authorRepo;
        }

        public async Task<ServiceResponse<object>> AddAuthorAsync(AddAuthorDto newAuthor)
        {
            ServiceResponse<object> response = new ServiceResponse<object>();

            try
            {
                var authorID = await _autherRepo.AddAuthor(_mapper.Map<Author>(newAuthor));
                response.Data = new { Author = authorID };
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

        public async Task<ServiceResponse<string>> DeleteAuthorAsync(int authorID)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();

            try
            {
                await _autherRepo.DeleteAuthor(authorID);
                response.Data = "Deleted";
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
        

        public async Task<ServiceResponse<List<GetAuthorDto>>> GetAllAuthorsAsync()
        {
            ServiceResponse<List<GetAuthorDto>> response = new ServiceResponse<List<GetAuthorDto>>();

            try
            {
                var dbAuthors = await _autherRepo.GetAuthors();
                response.Data = dbAuthors.Select(b => _mapper.Map<GetAuthorDto>(b)).ToList();
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

        public async Task<ServiceResponse<GetAuthorDto>> GetAuthorByIDAsync(int authorID)
        {
            ServiceResponse<GetAuthorDto> response = new ServiceResponse<GetAuthorDto>();

            try
            {
                var dbAuthor = await _autherRepo.GetAuthor(authorID);
                response.Data = _mapper.Map<GetAuthorDto>(dbAuthor);
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

        public async Task<ServiceResponse<GetAuthorDto>> UpdateAuthorAsync(UpdateAuthorDto updatedAuthor)
        {
            ServiceResponse<GetAuthorDto> response = new ServiceResponse<GetAuthorDto>();

            try
            {
                var dbBook = await _autherRepo.UpdateAuthor(_mapper.Map<Author>(updatedAuthor));
                response.Data = _mapper.Map<GetAuthorDto>(dbBook);
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