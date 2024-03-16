using LibraryBackend.Database;
using MediatR;

namespace LibraryBackend.Features.Genres {
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