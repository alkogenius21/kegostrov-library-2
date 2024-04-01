using LibraryBackend.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace LibraryBackend.Features.Books {
    /// <summary>
    /// Логика получения книги из базы по его Id
    /// </summary>
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly ApplicationDbContext _context;
        private readonly ConnectionMultiplexer _redis;

        public GetBookByIdQueryHandler(ApplicationDbContext context, ConnectionMultiplexer redis)
        {
            _redis = redis;
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
            var cacheKey = $"book:{request.BookId}";
            var redisDb = _redis.GetDatabase();
            var cachedBook = await redisDb.StringGetAsync(cacheKey);
            if (!cachedBook.IsNullOrEmpty)
            {
                return JsonConvert.DeserializeObject<Book>(cachedBook);
            }
            var response = await _context.Books
                .Include(book => book.Genre)
                .Include(book => book.BBK)
                .Include(book => book.UDK)
                .Include(book => book.Author)
                .FirstOrDefaultAsync(b => b.BookId == request.BookId);
            if (response != null)
            {
                await redisDb.StringSetAsync(cacheKey, JsonConvert.SerializeObject(response), TimeSpan.FromMinutes(10));
            }

            return response;
        }
    }
}