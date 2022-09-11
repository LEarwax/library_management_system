using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_management_system.Dtos.Book;

namespace library_management_system.Services.BookService
{
    public interface IBookService
    {
        Task<ServiceResponse<GetBookDto>> AddBookAsync(AddBookDto newBook);
        Task<ServiceResponse<GetBookDto>> UpdateBookAsync(UpdateBookDto updatedBook);
        Task<ServiceResponse<List<GetBookDto>>> GetAllBooksAsync();
        Task<ServiceResponse<GetBookDto>> GetBookByIDAsync(int id);
    }
}