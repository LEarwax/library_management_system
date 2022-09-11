using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using library_management_system.Dtos.Book;

namespace library_management_system
{
    public class AutoMapperProfile : Profile
    {
        
        public AutoMapperProfile()
        {
            CreateMap<Book, GetBookDto>();    
            CreateMap<AddBookDto, Book>();
        }
    }
}