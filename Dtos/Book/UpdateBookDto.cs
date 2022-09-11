using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Dtos.Book
{
    public class UpdateBookDto
    {
        public int BookID { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public int CopiesOwned { get; set; }
        public int CategoryID { get; set; }
    }
}