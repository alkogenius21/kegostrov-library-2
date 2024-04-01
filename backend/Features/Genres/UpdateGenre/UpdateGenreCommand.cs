using LibraryBackend.Database;
using MediatR;

namespace LibraryBackend.Features.Genres 
{
    /// <summary>
    /// Модель данных для обновления жанра
    /// </summary>
    public class UpdateGenreCommand : IRequest<Genre> {

        /// <summary>
        /// Идентификатор жанра
        /// </summary>
        public Guid GenreId { get; set; }
        /// <summary>
        /// Название жанра
        /// </summary>
        public required string GenreName { get; set; }
    }
}