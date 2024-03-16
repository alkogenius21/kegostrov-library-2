using LibraryBackend.Database;
using LibraryBackend.Features.Books;
using LibraryBackend.Models.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBackend.Controllers {

    /// <summary>
    /// Контроллер для работы с книгой
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="mediator">экземпляр класса MediaTr</param>
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Метод находит книги в базе данных.
        /// </summary>
        /// <param name="query">Параметры запроса</param>
        /// <returns>Список книг</returns>
        [HttpGet]
        public async Task<ActionResult<BookListViewModel>> GetBooks([FromQuery] GetBooksQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Метод находит книгу в базе данных по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Модель представления книги</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Book))]
        [ProducesResponseType(404)]
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

        /// <summary>
        /// Метод создает новую книгу в базе данных.
        /// </summary>
        /// <param name="command">Модель данных для создания книги</param>
        /// <returns></returns>
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

        /// <summary>
        /// Метод обновляет данные о книге.
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <param name="command">Модель данных книги</param>
        /// <returns>Модель представления книги</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, UpdateBookCommand command)
        {
            if (id != command.BookId)
            {
                return BadRequest("ОШИБКА: Идентификатор книги не совпадает с передаными данными");
            }
            try {
                command.BookId = id;
                var result = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetBookById), new { id = result.BookId }, result);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Метод частично обновляет данные о книге.
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <param name="command">Модель данных книги</param>
        /// <returns>Представление книги</returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBook(Guid id, UpdateBookCommand command) {
            if (id != command.BookId)
            {
                return BadRequest("ОШИБКА: Идентификатор книги не совпадает с передаными данными");
            }
            try {
                command.BookId = id;
                var result = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetBookById), new { id = result.BookId }, result);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Метод удаляет книгу из базы данных.
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>201 - если книга удалена, 400 - если ошибка</returns>
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