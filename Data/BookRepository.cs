using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Task<Book> AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(int Book)
        {
            throw new NotImplementedException();
        }

        public Task<Book> UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}