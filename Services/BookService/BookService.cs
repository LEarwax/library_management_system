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

        public async Task<ServiceResponse<object>> AddBookAsync(AddBookDto newBook)
        {
            ServiceResponse<object> response = new ServiceResponse<object>();

            try
            {
                var bookID = await _repo.AddBook(_mapper.Map<Book>(newBook));
                response.Data = new { BookID = bookID };
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

        public async Task<ServiceResponse<List<GetBookDto>>> GetAllBooksAsync()
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

        public async Task<ServiceResponse<GetBookDto>> GetBookByIDAsync(int id)
        {
            ServiceResponse<GetBookDto> response = new ServiceResponse<GetBookDto>();

            try
            {
                var dbBook = await _repo.GetBook(id);
                response.Data = _mapper.Map<GetBookDto>(dbBook);
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

        public async Task<ServiceResponse<GetBookDto>> UpdateBookAsync(UpdateBookDto updatedBook)
        {
            ServiceResponse<GetBookDto> response = new ServiceResponse<GetBookDto>();

            try
            {
                var dbBook = await _repo.UpdateBook(_mapper.Map<Book>(updatedBook));
                response.Data = _mapper.Map<GetBookDto>(dbBook);
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

        public async Task<ServiceResponse<string>> DeleteBookAsync(int bookID)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();

            try
            {
                await _repo.DeleteBook(bookID);
                response.Data = "Deleted";
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