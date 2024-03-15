using Microsoft.AspNetCore.Mvc;
using MediatR;
using backend.Models.Genres;
using backend.Features.Genres.GetGenres;

namespace backend.Controllers {
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GenresController : ControllerBase {
        private readonly IMediator _mediator;

        public GenresController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GenresListViewModel>> GetGenres([FromQuery] GetGenresQuery query) {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}