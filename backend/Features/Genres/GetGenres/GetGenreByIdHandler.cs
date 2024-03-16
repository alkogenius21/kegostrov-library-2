using backend.Database;
using MediatR;

namespace backend.Features.Genres {
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, Genre> {
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Конструктор класса GetGenreByIdQueryHandler
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public GetGenreByIdQueryHandler(ApplicationDbContext context) {
            _context = context;
        }

        /// <summary>
        /// Метод находит жанр в базе по его Id и возвращает его
        /// </summary>
        /// <param name="request">Параметр запроса</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Модель жанра</returns>
        public async Task<Genre> Handle(
            GetGenreByIdQuery request,
            CancellationToken cancellationToken) {
            return await _context.Genres.FindAsync(request.GenreId);
        }
    }
}