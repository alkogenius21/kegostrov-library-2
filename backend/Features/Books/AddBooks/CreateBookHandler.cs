using backend.Database;
using MediatR;

namespace backend.Features.Books.AddBooks {
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly ApplicationDbContext _context;

        public CreateBookCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {   
            var book = new Book
            {
                Title = request.Title,
                Description = request.Description,
                Author = request.Author,
                Publisher = request.Publisher,
                PublishDate = request.PublishDate,
                UploadDate = DateOnly.FromDateTime(DateTime.Now)
            };

            if (request.BbkId.HasValue)
            {
                var bbk = await _context.BBKS.FindAsync(request.BbkId);
                if (bbk != null)
                {
                    book.BBK = bbk;
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
                    book.UDK = udk;
                }
                else 
                {
                    throw new Exception("ОШИБКА: Не удалось найти ББК");
                }
            }

            if (request.GenreId.HasValue) {
                var genre = await _context.Genres.FindAsync(request.GenreId);
                if (genre != null) {
                    book.Genre = genre;
                }
                else 
                {
                    throw new Exception("ОШИБКА: Не удалось найти жанр");
                }
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync(cancellationToken);

            return book;
        }
    }
}