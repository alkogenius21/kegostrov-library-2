using backend.Database;
using MediatR;

namespace backend.Features.Genres {
    /// <summary>
    /// Модель представления данных для создания записи жанров
    /// </summary>
    public class CreateGenreCommand : IRequest<Genre> {
        /// <summary>
        /// Название жанра
        /// </summary>
        public required string GenreName { get; set; }
    }
}