using BusinessLayer.Services;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService) 
        { 
            _bookService = bookService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all books")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll() 
        {
            var result = await _bookService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a book by id")]
        public async Task<ActionResult<Book>> GetById(int id) 
        {
            var result = await _bookService.GetById(id);
            if (result is null) return NotFound("The book doesn´t exist");
            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a book")]
        public async Task<ActionResult<Book>> PostBook(Book book) 
        {
            var result = await _bookService.PostBook(book);
            return CreatedAtAction(nameof(GetById), new { Id = result.Id}, result);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Modifies an existing book")]
        public async Task<ActionResult<Book?>> PutBook(int id, Book book) 
        {
            var b = await _bookService.PutBook(id, book);
            if (b is null) return NotFound();
            else if (b.Id != id) return BadRequest();
            return Ok(b);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes a book")]
        public async Task<ActionResult> DeleteBook(int id) 
        {
            await _bookService.DeleteBook(id);   
            return Ok("Book deleted");
        }
    }
}
