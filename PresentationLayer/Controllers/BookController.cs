using BusinessLayer.Services;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var result = await _bookService.GetAll();
            return Ok(result);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var result = await _bookService.GetById(id);

            if (result is null) 
                return NotFound(new { message = "The book doesn't exist." });

            return Ok(result);
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _bookService.PostBook(book);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> PutBook(int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != book.Id)
                return BadRequest(new { message = "Id in URL and body do not match." });

            var result = await _bookService.PutBook(id, book);

            if (result is null) 
                return NotFound(new { message = "The book doesn't exist." });

            return Ok(result);
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBook(id);

            if (result is null) 
                return NotFound(new { message = "The book doesn't exist." });

            return Ok(new { message = "Book deleted." });
        }
    }
}
