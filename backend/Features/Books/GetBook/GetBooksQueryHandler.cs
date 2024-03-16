using LibraryBackend.Database;
using LibraryBackend.Models.Books;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryBackend.Features.Books {
    /// <summary>
    /// Логика получения списка книг
    /// </summary>
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, BookListViewModel>
    {
        private readonly ApplicationDbContext _context;

        public GetBooksQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод находит книги в базе
        /// </summary>
        /// <param name="request">Номер страницы и колчество записей на одной странце</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Список книг</returns>
        public async Task<BookListViewModel> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _context.Books
                .OrderByDescending(b => b.UploadDate)
                .Include(book => book.Genre)
                .Include(book => book.BBK)
                .Include(book => book.UDK)
                .Include(book => book.Author)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken: cancellationToken);

            return new BookListViewModel
            {
                Books = books
            };
        }
    }
}