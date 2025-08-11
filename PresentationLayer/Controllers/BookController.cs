using DataLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookHouseDBContext _context;

        public BookController(BookHouseDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        /// <summary>
        /// Gets a book by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById([FromRoute] int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null)
                return NotFound($"Book with ID {id} not found.");

            return Ok(book);
        }

        /// <summary>
        /// Adds a new book.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody, Required] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        /// <summary>
        /// Updates an existing book.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> PutBook([FromRoute] int id, [FromBody, Required] Book book)
        {
            if (id != book.Id)
                return BadRequest("The book ID does not match the provided ID.");

            var existingBook = await _context.Books.FindAsync(id);

            if (existingBook is null)
                return NotFound($"Book with ID {id} not found.");

            _context.Entry(existingBook).CurrentValues.SetValues(book);
            await _context.SaveChangesAsync();

            return Ok(existingBook);
        }

        /// <summary>
        /// Deletes a book by its ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null)
                return NotFound($"Book with ID {id} not found.");

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
