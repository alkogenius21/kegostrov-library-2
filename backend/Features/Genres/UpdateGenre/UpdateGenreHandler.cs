using LibraryBackend.Database;
using MediatR;

namespace LibraryBackend.Features.Genres {
    public class UpdateGenreHandler : IRequestHandler<UpdateGenreCommand, Genre> {
        private readonly ApplicationDbContext _context;

        public UpdateGenreHandler(ApplicationDbContext context) {
            _context = context;
        }
        
        /// <summary>
        /// Метод обновляет жанр в БД
        /// </summary>
        /// <param name="request">Модель представления данных</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Жанр</returns>
        /// <exception cref="Exception">Вызывается если такой жанр не существует</exception>
        public async Task<Genre> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)  {
            var currentGenre = await _context.Genres.FindAsync(request.GenreId);
            if (currentGenre == null) {
                throw new Exception($"ОШИБКА: Не удалось найти жанр с ID {request.GenreId}");
            }
            currentGenre.GenreName = request.GenreName ?? currentGenre.GenreName;
            await _context.SaveChangesAsync();
            return currentGenre;
        }
    }
}