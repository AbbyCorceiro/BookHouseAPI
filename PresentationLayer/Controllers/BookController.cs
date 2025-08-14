using BusinessLayer.Services;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService) 
        { 
            _bookService = bookService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll() 
        {
            var result = await _bookService.GetAll();
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Book>>> GetById(int id) 
        {
            var result = await _bookService.GetById(id);
            if (result is null) return NotFound("The book doesn´t exist");
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Book>> PostBook(Book book) 
        {
            var result = await _bookService.PostBook(book);
            return CreatedAtAction(nameof(GetById), new { Id = book.Id}, book);
        }

        [HttpPut("modify")]
        public async Task<ActionResult<Book?>> PutBook(int id, Book book) 
        {
            var b = await _bookService.PutBook(id, book);
            if (b is null) return NotFound();
            else if (b.Id != id) return BadRequest();
            return Ok(b);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteBook(int id) 
        {
            await _bookService.DeleteBook(id);   
            return Ok("Book deleted");
        }
    }
}
