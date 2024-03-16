using Microsoft.AspNetCore.Mvc;
using MediatR;
using backend.Models.Genres;
using backend.Features.Genres;

namespace backend.Controllers {
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



        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenreCommand command) {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}