using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Dtos.Book.Author
{
    public class UpdateAuthorDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}