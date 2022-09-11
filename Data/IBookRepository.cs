using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Data
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int bookID);
        Task<int> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task DeleteBook(int Book);
    }
}