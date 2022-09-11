using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_management_system.Dtos.Book;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public BookRepository(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<Book> GetBook(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.BookID == id);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<int> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.BookID;
        }

        public async Task<Book> UpdateBook(Book updatedBook)
        {
            Book dbBook = await _context.Books.FirstOrDefaultAsync(b => b.BookID == updatedBook.BookID);
            dbBook.Title = updatedBook.Title;
            dbBook.PublicationDate = updatedBook.PublicationDate;
            dbBook.CopiesOwned = updatedBook.CopiesOwned;
            dbBook.CategoryID = updatedBook.CategoryID;
            await _context.SaveChangesAsync();
            return updatedBook;
        }

        public async Task DeleteBook(int bookID)
        {
            using (SqlConnection cnn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await cnn.OpenAsync();
                var sql = $@"
                        DELETE FROM dbo.book 
                        WHERE BookID = {bookID}";

                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    var reader = await cmd.ExecuteNonQueryAsync();
                }
                
                await cnn.CloseAsync();
            }
        }

        
    }
}