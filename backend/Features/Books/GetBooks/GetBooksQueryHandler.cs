using backend.Database;
using backend.Models.Books;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace backend.Features.Books.GetBooks {
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, BookListViewModel>
    {
        private readonly ApplicationDbContext _context;

        public GetBooksQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BookListViewModel> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _context.Books
                .OrderByDescending(b => b.UploadDate)
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