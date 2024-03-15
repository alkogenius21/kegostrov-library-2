using backend.Database;
using MediatR;

namespace backend.Features.Books.PutBooks {
    /// <summary>
    /// Логика изменений данных о книге
    /// </summary>
    public class PutBookHandler : IRequestHandler<PutBookCommand, Book> {
        private readonly ApplicationDbContext _context;

        public PutBookHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод изменения данных о книге
        /// </summary>
        /// <param name="request">Модель данных для изменения книги</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Модель представления книги</returns>
        /// <exception cref="Exception">Вызывается если не найдены: Книга, УДК, ББК, Жанр</exception>
        public async Task<Book> Handle(PutBookCommand request, CancellationToken cancellationToken) {
            var currentBook = await _context.Books.FindAsync(request.BookId);

            if (currentBook == null) {
                throw new Exception($"ОШИБКА: Не удалось найти книгу с ID {request.BookId}");
            }
            currentBook.Title = request.Title ?? currentBook.Title;
            currentBook.Description = request.Description ?? currentBook.Description;
            currentBook.Author = request.Author ?? currentBook.Author;
            currentBook.Publisher = request.Publisher ?? currentBook.Publisher;
            currentBook.PublishDate = request.PublishDate ?? currentBook.PublishDate;

            if (request.BbkId.HasValue)
            {
                var bbk = await _context.BBKS.FindAsync(request.BbkId);
                if (bbk != null)
                {
                    currentBook.BBK = bbk ?? currentBook.BBK;
                }
                else 
                {
                    throw new Exception("ОШИБКА: Не удалось найти УДК");
                }
            }

            if (request.UdkId.HasValue)
            {
                var udk = await _context.UDKS.FindAsync(request.UdkId);
                if (udk != null)
                {
                    currentBook.UDK = udk ?? currentBook.UDK;
                }
                else 
                {
                    throw new Exception("ОШИБКА: Не удалось найти ББК");
                }
            }

            if (request.GenreId.HasValue) {
                var genre = await _context.Genres.FindAsync(request.GenreId);
                if (genre != null) {
                    currentBook.Genre = genre ?? currentBook.Genre;
                }
                else 
                {
                    throw new Exception("ОШИБКА: Не удалось найти жанр");
                }
            }

            await _context.SaveChangesAsync();

            return currentBook;
        }
    }
}