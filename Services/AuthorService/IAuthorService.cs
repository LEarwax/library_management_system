using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_management_system.Dtos.Book.Author;

namespace library_management_system.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<ServiceResponse<object>> AddAuthorAsync(AddAuthorDto newAuthor);
        Task<ServiceResponse<GetAuthorDto>> UpdateAuthorAsync(UpdateAuthorDto updatedAuthor);
        Task<ServiceResponse<List<GetAuthorDto>>> GetAllAuthorsAsync();
        Task<ServiceResponse<GetAuthorDto>> GetAuthorByIDAsync(int authorID);
        Task<ServiceResponse<string>> DeleteAuthorAsync(int authorID);
    }
}