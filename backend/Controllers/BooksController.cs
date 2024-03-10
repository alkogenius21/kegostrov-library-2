using backend.Database;
using backend.Features.Books.AddBooks;
using backend.Features.Books.GetBooks;
using backend.Models.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        [Route("List")]
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
    }
}