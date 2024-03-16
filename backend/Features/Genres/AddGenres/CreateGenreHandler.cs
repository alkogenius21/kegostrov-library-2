using backend.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace backend.Features.Genres {
    public class CreateGenreHandler : IRequestHandler<CreateGenreCommand, Genre> {
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Конструктор класса CreateGenreHandler
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public CreateGenreHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод создает жанр в базе данных
        /// </summary>
        /// <param name="request">Модель данных для создание жанра</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Созданный жанр</returns>
        /// <exception cref="Exception">Вызывается если такой жанр уже существует</exception>
        public async Task<Genre> Handle(CreateGenreCommand request, CancellationToken cancellationToken) {
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.GenreName == request.GenreName);
            if (genre != null) {
                throw new Exception("ОШИБКА: Данный жанр уже существует");
            }
            var newGenre = new Genre {
                GenreName = request.GenreName
            };
            _context.Genres.Add(newGenre);
            await _context.SaveChangesAsync(cancellationToken);
            return newGenre;
        }
    }
}