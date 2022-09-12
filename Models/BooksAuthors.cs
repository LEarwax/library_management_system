using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Models
{
    public class BooksAuthors
    {
        public int BooksAuthorsID { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}