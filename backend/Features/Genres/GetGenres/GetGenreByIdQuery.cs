using backend.Database;
using MediatR;

namespace backend.Features.Genres {
    /// <summary>
    /// Id жанра в параметрах запроса
    /// </summary>
    public class GetGenreByIdQuery : IRequest<Genre> {
        /// <summary>
        /// Идентификатор жанра
        /// </summary>
        public Guid GenreId { get; set; }
    }
}