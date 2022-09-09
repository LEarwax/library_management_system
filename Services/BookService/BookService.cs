using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using library_management_system.Data;
using library_management_system.Dtos.Book;

namespace library_management_system.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;
    public BookService(IBookRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

        public async Task<ServiceResponse<List<GetBookDto>>> GetAllBooks()
        {
            ServiceResponse<List<GetBookDto>> response = new ServiceResponse<List<GetBookDto>>();

            try
            {
                var dbBooks = await _repo.GetBooks();
                response.Data = dbBooks.Select(b => _mapper.Map<GetBookDto>(b)).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.StackTrace = ex.StackTrace;                                
            }
            
            return response;
        }
    }
}