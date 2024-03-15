using backend.Database;
using backend.Features.Books.AddBooks;
using backend.Features.Books.DeleteBooks;
using backend.Features.Books.GetBooks;
using backend.Features.Books.PutBooks;
using backend.Models.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers {

    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet]
        public async Task<ActionResult<BookListViewModel>> GetBooks([FromQuery] GetBooksQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(Guid id)
        {
            var query = new GetBookByIdQuery { BookId = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(CreateBookCommand command)
        {
            try {
                var result = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetBookById), new { id = result.BookId }, result);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return StatusCode(400, ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, PutBookCommand command)
        {
            try {
                command.BookId = id;
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            try {
                await _mediator.Send(new DeleteBookCommand { BookId = id });
                return NoContent();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }     
    }
}