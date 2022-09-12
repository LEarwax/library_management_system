using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new Category[]
                {
                    new Category { CategoryName = "Western" },
                    new Category { CategoryName = "SciFi" },
                    new Category { CategoryName = "Crime/Noir" },
                    new Category { CategoryName = "History" },
                    new Category { CategoryName = "Adventure" }
                };

                foreach (Category c in categories)
                {
                    context.Categories.Add(c);
                }

                context.SaveChanges();
            }

            if (!context.Books.Any())
            {
                var books = new Book[]
                {
                    new Book { Title = "Blood Merdian", PublicationDate = new DateTime(1985, 4, 01), CopiesOwned = 2, CategoryID = 1 },
                    new Book { Title = "The Fifth Head of Cerberus", PublicationDate = new DateTime(1851, 10, 18), CopiesOwned = 1, CategoryID = 3 },
                    new Book { Title = "Moby Dick", PublicationDate = new DateTime(1985, 4, 01), CopiesOwned = 2, CategoryID = 5 },
                    new Book { Title = "American Tabloid", PublicationDate = new DateTime(1995, 1, 01), CopiesOwned = 2, CategoryID = 3 },
                };

                foreach (Book b in books)
                {
                    context.Books.Add(b);
                }
                
                context.SaveChanges();
            }
        }
    }
}