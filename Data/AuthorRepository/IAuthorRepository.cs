using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Data.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthors();
        Task<Author> GetAuthor(int authorID);
        Task<int> AddAuthor(Author author);
        Task<Author> UpdateAuthor(Author author);
        Task DeleteAuthor(int Author);
    }
}