using backend.Database;
using MediatR;

namespace backend.Features.Books {
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
            var response = await _context.Books.FindAsync(request.BookId);
            return response;
        }
    }
}