using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Dtos.Book.Author
{
    public class GetAuthorDto
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}