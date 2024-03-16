using Microsoft.AspNetCore.Mvc;
using MediatR;
using LibraryBackend.Models.Genres;
using LibraryBackend.Features.Genres;
using LibraryBackend.Database;

namespace LibraryBackend.Controllers {
    /// <summary>
    /// Контроллер, описывающий работу с жанрами
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GenresController : ControllerBase {
        private readonly IMediator _mediator;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="mediator">экземпляр класса MediaTr</param>
        public GenresController(IMediator mediator) {
            _mediator = mediator;
        }
        /// <summary>
        /// Метод для получения списка жанров
        /// </summary>
        /// <param name="query">Параметры запроса</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<GenresListViewModel>> GetGenres([FromQuery] GetGenresQuery query) {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        /// <summary>
        /// Метод для получения жанра по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор жанра</param>
        /// <returns>Модель жанра</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(Guid id) {
            var query = new GetGenreByIdQuery { GenreId = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenreCommand command) {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}