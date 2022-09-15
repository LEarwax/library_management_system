using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using library_management_system.Dtos.Book;
using library_management_system.Dtos.Book.Author;
using library_management_system.Dtos.Category;

namespace library_management_system
{
    public class AutoMapperProfile : Profile
    {
        
        public AutoMapperProfile()
        {
            CreateMap<Book, GetBookDto>();    
            CreateMap<AddBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();

            CreateMap<AddAuthorDto, Author>();
            CreateMap<Author, GetAuthorDto>();
            CreateMap<UpdateAuthorDto, Author>();

            CreateMap<AddCategoryDto, Category>();
            CreateMap<Category, GetCategoryDto>();
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}