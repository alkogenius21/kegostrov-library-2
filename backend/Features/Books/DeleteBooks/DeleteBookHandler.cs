using backend.Database;
using MediatR;

namespace backend.Features.Books.DeleteBooks {
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteBookCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.BookId);

            if (book == null)
            {
                throw new Exception($"ОШИБКА: Не удалось найти книгу с ID {request.BookId}");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}