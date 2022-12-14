// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using library_management_system.Data;

#nullable disable

namespace library_management_system.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220914034843_AddFines")]
    partial class AddFines
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("library_management_system.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("library_management_system.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("CopiesOwned")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("library_management_system.Models.BooksAuthors", b =>
                {
                    b.Property<int>("BooksAuthorsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BooksAuthorsID"), 1L, 1);

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.HasKey("BooksAuthorsID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("BookID");

                    b.ToTable("BooksAuthors");
                });

            modelBuilder.Entity("library_management_system.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("library_management_system.Models.Fine", b =>
                {
                    b.Property<int>("FineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FineID"), 1L, 1);

                    b.Property<int?>("BookID")
                        .HasColumnType("int");

                    b.Property<double>("FineAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("FineDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LoanID")
                        .HasColumnType("int");

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.HasKey("FineID");

                    b.HasIndex("BookID");

                    b.HasIndex("LoanID");

                    b.HasIndex("MemberID");

                    b.ToTable("Fines");
                });

            modelBuilder.Entity("library_management_system.Models.Loan", b =>
                {
                    b.Property<int>("LoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanID"), 1L, 1);

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LoanID");

                    b.HasIndex("BookID");

                    b.HasIndex("MemberID");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("library_management_system.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberStatusID")
                        .HasColumnType("int");

                    b.HasKey("MemberID");

                    b.HasIndex("MemberStatusID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("library_management_system.Models.MemberStatus", b =>
                {
                    b.Property<int>("MemberStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberStatusID"), 1L, 1);

                    b.Property<string>("StatusValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberStatusID");

                    b.ToTable("MemberStatuses");
                });

            modelBuilder.Entity("library_management_system.Models.Book", b =>
                {
                    b.HasOne("library_management_system.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("library_management_system.Models.BooksAuthors", b =>
                {
                    b.HasOne("library_management_system.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("library_management_system.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("library_management_system.Models.Fine", b =>
                {
                    b.HasOne("library_management_system.Models.Book", null)
                        .WithMany("Fines")
                        .HasForeignKey("BookID");

                    b.HasOne("library_management_system.Models.Loan", "Loan")
                        .WithMany()
                        .HasForeignKey("LoanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("library_management_system.Models.Member", "Member")
                        .WithMany("Fines")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("library_management_system.Models.Loan", b =>
                {
                    b.HasOne("library_management_system.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("library_management_system.Models.Member", "Member")
                        .WithMany("Loans")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("library_management_system.Models.Member", b =>
                {
                    b.HasOne("library_management_system.Models.MemberStatus", "MemberStatus")
                        .WithMany("Members")
                        .HasForeignKey("MemberStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MemberStatus");
                });

            modelBuilder.Entity("library_management_system.Models.Book", b =>
                {
                    b.Navigation("Fines");
                });

            modelBuilder.Entity("library_management_system.Models.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("library_management_system.Models.Member", b =>
                {
                    b.Navigation("Fines");

                    b.Navigation("Loans");
                });

            modelBuilder.Entity("library_management_system.Models.MemberStatus", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
