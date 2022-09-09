using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using library_management_system.Services.BookService;
using library_management_system.Dtos.Book;

namespace library_management_system.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetBookDto>>> Get()
        {
            return Ok(await _bookService.GetAllBooks());
        }
    }
}