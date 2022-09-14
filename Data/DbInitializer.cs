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

            if (!context.Authors.Any())
            {
                var authors = new Author[]
                {
                    new Author { FirstName = "Cormac", LastName = "McCarthy" },
                    new Author { FirstName = "Gene", LastName = "Wolfe" },
                    new Author { FirstName = "Herman", LastName = "Melville" },
                    new Author { FirstName = "James", LastName = "Elroy" }
                };

                foreach (Author a in authors)
                {
                    context.Authors.Add(a);
                }

                context.SaveChanges();
            }

            if (!context.BooksAuthors.Any())
            {
                var booksAuthors = new BooksAuthors[]
                {
                    new BooksAuthors { BookID = 1, AuthorID = 1 },
                    new BooksAuthors { BookID = 2, AuthorID = 2},
                    new BooksAuthors { BookID = 3, AuthorID = 3 },
                    new BooksAuthors { BookID = 4, AuthorID = 4 }
                };

                foreach (BooksAuthors ba in booksAuthors)
                {
                    context.BooksAuthors.Add(ba);
                }

                context.SaveChanges();
            }

            if (!context.MemberStatuses.Any())
            {
                var memberStatuses = new MemberStatus[]
                {
                    new MemberStatus { StatusValue = "Active" },
                    new MemberStatus { StatusValue = "Inactive"},
                    new MemberStatus { StatusValue = "Suspended" }
                };

                foreach (MemberStatus ms in memberStatuses)
                {
                    context.MemberStatuses.Add(ms);
                }

                context.SaveChanges();
            }

            if (!context.Members.Any())
            {
                var members = new Member[]
                {
                    new Member { FirstName = "Nicholas", LastName = "Dowling", JoinedDate = DateTime.UtcNow, MemberStatusID = 1 },
                    new Member { FirstName = "Karla", LastName = "Ruiz", JoinedDate = DateTime.UtcNow, MemberStatusID = 2 },
                    new Member { FirstName = "Byron", LastName = "Watson", JoinedDate = DateTime.UtcNow, MemberStatusID = 1 },
                    new Member { FirstName = "Jamie", LastName = "Burkart", JoinedDate = DateTime.UtcNow, MemberStatusID = 3 },
                    new Member { FirstName = "Evan", LastName = "Hill", JoinedDate = DateTime.UtcNow, MemberStatusID = 1 }
                };

                foreach (Member m in members)
                {
                    context.Members.Add(m);
                }

                context.SaveChanges();
            }

            if (!context.Loans.Any())
            {
                var loans = new Loan[]
                {
                    new Loan { BookID = 1, MemberID = 1, LoanDate = DateTime.Now, ReturnedDate = null },
                    new Loan { BookID = 2, MemberID = 2, LoanDate = DateTime.Now, ReturnedDate = null },
                    new Loan { BookID = 3, MemberID = 3, LoanDate = DateTime.Now, ReturnedDate = null }
                };

                foreach (Loan l in loans)
                {
                    context.Loans.Add(l);
                }

                context.SaveChanges();
            }

            if (!context.Fines.Any())
            {
                var fines = new Fine[]
                {
                    new Fine { MemberID = 2, LoanID = 1, FineDate = new DateTime(2022, 10, 1), FineAmount = 10.00 }
                };

                foreach (Fine f in fines)
                {
                    context.Fines.Add(f);
                }

                context.SaveChanges();
            }

            if (!context.ReservationStatuses.Any())
            {
                var reservationStatuses = new ReservationStatus[]
                {
                    new ReservationStatus { Status = "Available" },
                    new ReservationStatus { Status = "Reserved" }
                };

                foreach (ReservationStatus rs in reservationStatuses)
                {
                    context.ReservationStatuses.Add(rs);
                }

                context.SaveChanges();
            }

            if (!context.Reservations.Any())
            {
                var reservations = new Reservation[]
                {
                    new Reservation { BookID = 1, MemberID = 1, ReservationDate = DateTime.Now, ReservationStatusID = 1 },
                    new Reservation { BookID = 3, MemberID = 3, ReservationDate = DateTime.Now, ReservationStatusID = 2 }
                };

                foreach (Reservation r in reservations)
                {
                    context.Reservations.Add(r);
                }

                context.SaveChanges();
            }
        }
    }
}