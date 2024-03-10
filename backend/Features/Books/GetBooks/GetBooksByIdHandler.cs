using backend.Database;
using MediatR;

namespace backend.Features.Books.GetBooks {
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly ApplicationDbContext _context;

        public GetBookByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.FindAsync(request.BookId);
        }
    }
}