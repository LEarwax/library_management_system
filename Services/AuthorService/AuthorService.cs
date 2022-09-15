using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_management_system.Dtos.Book.Author;

namespace library_management_system.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        public Task<ServiceResponse<object>> AddAuthorAsync(AddAuthorDto newBook)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<string>> DeleteAuthorAsync(int authorID)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetAuthorDto>>> GetAllAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetAuthorDto>> GetAuthorByIDAsync(int authorID)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetAuthorDto>> UpdateAuthorAsync(UpdateAuthorDto updatedBook)
        {
            throw new NotImplementedException();
        }
    }
}