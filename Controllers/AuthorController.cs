using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_management_system.Dtos.Book.Author;
using library_management_system.Services.AuthorService;
using Microsoft.AspNetCore.Mvc;

namespace library_management_system.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<ActionResult<GetAuthorDto>> AddAuthorAsync([FromBody]AddAuthorDto newAuthor)
        {
            return Ok(await _authorService.AddAuthorAsync(newAuthor));
        }

        [HttpPut]
        public async Task<ActionResult<GetAuthorDto>> UpdateAuthorAsync([FromBody]UpdateAuthorDto updatedAuthor)
        {
            return Ok(await _authorService.UpdateAuthorAsync(updatedAuthor));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetAuthorDto>>> GetAsync()
        {
            return Ok(await _authorService.GetAllAuthorsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAuthorDto>> GetOneAsync(int id)
        {
            return Ok(await _authorService.GetAuthorByIDAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteAsync(int id)
        {
            return Ok(await _authorService.DeleteAuthorAsync(id));
        }
    }
}