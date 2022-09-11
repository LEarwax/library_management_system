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

        public BookRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Book> GetBook(int id)
        {

            using (SqlConnection cnn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                cnn.Open();
                var sql = $"SELECT * FROM [dbo].[book] WHERE BookID = {id}";
                
                var dbBook = new Book();

                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    var reader = cmd.ExecuteReader();

                    reader.Read();
                    Int32.TryParse(reader["BookID"].ToString(), out int bookID);
                    Int32.TryParse(reader["CopiesOwned"].ToString(), out int copiesOwned);
                    Int32.TryParse(reader["CategoryID"].ToString(), out int categoryID);

                    dbBook = new Book
                    {
                        BookID = bookID,
                        Title = reader["Title"].ToString(),
                        PublicationDate = DateTime.Parse(reader["PublicationDate"].ToString()),
                        CopiesOwned = copiesOwned,
                        CategoryID = categoryID
                    };
                    
                }

                cnn.Close();
                return dbBook;
            }
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            List<Book> dbBooks = new List<Book>();
            
            using (SqlConnection cnn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                cnn.Open();
                var sql = "SELECT * FROM [dbo].[book]";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Int32.TryParse(reader["BookID"].ToString(), out int bookID);
                        Int32.TryParse(reader["CopiesOwned"].ToString(), out int copiesOwned);
                        Int32.TryParse(reader["CategoryID"].ToString(), out int categoryID);

                        var book = new Book
                        {
                            BookID = bookID,
                            Title = reader["Title"].ToString(),
                            PublicationDate = DateTime.Parse(reader["PublicationDate"].ToString()),
                            CopiesOwned = copiesOwned,
                            CategoryID = categoryID
                        };

                        dbBooks.Add(book);
                    }
                }
                
                cnn.Close();
                return dbBooks;
            }
            
        }

        public async Task<Book> AddBook(Book book)
        {
            var dbBook = new Book();
            
            
            using (SqlConnection cnn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await cnn.OpenAsync();
                var sql = $@"
                        INSERT INTO dbo.book (Title, PublicationDate, CopiesOwned, CategoryID)
                        OUTPUT INSERTED.BookID, INSERTED.Title, INSERTED.PublicationDate, INSERTED.CopiesOwned, INSERTED.CategoryID 
                        VALUES ('{book.Title}', '{book.PublicationDate}', {book.CopiesOwned}, {book.CategoryID})";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {

                    var reader = await cmd.ExecuteReaderAsync();
                    await reader.ReadAsync();
                    
                        Int32.TryParse(reader["BookID"].ToString(), out int bookID);
                        Int32.TryParse(reader["CopiesOwned"].ToString(), out int copiesOwned);
                        Int32.TryParse(reader["CategoryID"].ToString(), out int categoryID);

                        
                        dbBook.BookID = bookID;
                        dbBook.Title = reader["Title"].ToString();
                        dbBook.PublicationDate = DateTime.Parse(reader["PublicationDate"].ToString());
                        dbBook.CopiesOwned = copiesOwned;
                        dbBook.CategoryID = categoryID;
                    
                }
                
                await cnn.CloseAsync();
                return dbBook;
            }

        
        }

        public async Task<Book> UpdateBook(Book book)
        {
            var dbBook = new Book();

            using (SqlConnection cnn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await cnn.OpenAsync();
                var sql = $@"
                        UPDATE dbo.book 
                        SET Title = '{book.Title}', PublicationDate = '{book.PublicationDate}', CopiesOwned = '{book.CopiesOwned}', CategoryID = '{book.CategoryID}'
                        OUTPUT INSERTED.BookID, INSERTED.Title, INSERTED.PublicationDate, INSERTED.CopiesOwned, INSERTED.CategoryID 
                        WHERE BookID = {book.BookID}";

                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {

                    var reader = await cmd.ExecuteReaderAsync();
                    await reader.ReadAsync();
                    
                        Int32.TryParse(reader["BookID"].ToString(), out int bookID);
                        Int32.TryParse(reader["CopiesOwned"].ToString(), out int copiesOwned);
                        Int32.TryParse(reader["CategoryID"].ToString(), out int categoryID);

                        
                        dbBook.BookID = bookID;
                        dbBook.Title = reader["Title"].ToString();
                        dbBook.PublicationDate = DateTime.Parse(reader["PublicationDate"].ToString());
                        dbBook.CopiesOwned = copiesOwned;
                        dbBook.CategoryID = categoryID;
                }
                
                await cnn.CloseAsync();
                return dbBook;
            }
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