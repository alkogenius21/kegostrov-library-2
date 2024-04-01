using LibraryBackend.Database;
using LibraryBackend.Models.Books;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Newtonsoft.Json;


namespace LibraryBackend.Features.Books {
    /// <summary>
    /// Логика получения списка книг
    /// </summary>
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, BookListViewModel>
    {
        private readonly ApplicationDbContext _context;
        private readonly ConnectionMultiplexer _redis;

        public GetBooksQueryHandler(ApplicationDbContext context, ConnectionMultiplexer redis)
        {
            _redis = redis;
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
            var cacheKey = $"books:{request.Page}:{request.PageSize}";
            var cachedBooks = await _redis.GetDatabase().StringGetAsync(cacheKey);

            if (!cachedBooks.IsNullOrEmpty)
            {
                return JsonConvert.DeserializeObject<BookListViewModel>(cachedBooks);
            }

            var booksQuery = _context.Books
                .Include(book => book.Genre)
                .Include(book => book.BBK)
                .Include(book => book.UDK)
                .Include(book => book.Author)
                .OrderByDescending(b => b.UploadDate);

            if (!string.IsNullOrEmpty(request.Title))
                booksQuery = (IOrderedQueryable<Book>)booksQuery.Where(b => b.Title.Contains(request.Title));
            if (!string.IsNullOrEmpty(request.Description))
                booksQuery = (IOrderedQueryable<Book>)booksQuery.Where(b => b.Description.Contains(request.Description));
            if (!string.IsNullOrEmpty(request.Publisher))
                booksQuery = (IOrderedQueryable<Book>)booksQuery.Where(b => b.Publisher.Contains(request.Publisher));
            if (request.PublishDate.HasValue)
                booksQuery = (IOrderedQueryable<Book>)booksQuery.Where(b => b.PublishDate == request.PublishDate);

            var books = await booksQuery
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var viewModel = new BookListViewModel
            {
                Books = books
            };

            await _redis.GetDatabase().StringSetAsync(cacheKey, JsonConvert.SerializeObject(viewModel), TimeSpan.FromMinutes(10));

            return viewModel;
        }
    }
}