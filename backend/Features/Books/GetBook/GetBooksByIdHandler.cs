using LibraryBackend.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryBackend.Features.Books {
    /// <summary>
    /// Логика получения книги из базы по его Id
    /// </summary>
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly ApplicationDbContext _context;

        public GetBookByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод находит книгу в базе и возвращает его
        /// </summary>
        /// <param name="request">Id книги</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Модель данных найденной книги</returns>
        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.Books
            .Include(book => book.Genre)
            .Include(book => book.BBK)
            .Include(book => book.UDK)
            .Include(book => book.Author)
            .FirstOrDefaultAsync(b => b.BookId == request.BookId);
            return response;
        }
    }
}