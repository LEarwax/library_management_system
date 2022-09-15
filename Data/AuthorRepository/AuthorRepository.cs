using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Data.AuthorRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author.AuthorID;
        }

        public async Task DeleteAuthor(int id)
        {
            Author author = await _context.Authors.FirstAsync(a => a.AuthorID == id);
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<Author> GetAuthor(int id)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.AuthorID == id);
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            Author dbAuthor = await _context.Authors.FirstAsync(a => a.AuthorID == author.AuthorID);
            dbAuthor.FirstName = author.FirstName;
            dbAuthor.LastName = author.LastName;
            await _context.SaveChangesAsync();
            return author;
        }
    }
}