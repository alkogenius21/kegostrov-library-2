using backend.Database;
using MediatR;

namespace backend.Features.Books {
    /// <summary>
    /// Логика обработки удаления книги из базы
    /// </summary>
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteBookCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод находит книгу в базе и удаляет его
        /// </summary>
        /// <param name="request">Команда с id книги</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task, представляющий асинхронную операцию</returns>
        /// <exception cref="Exception">Вызывается, если не найден id книги</exception>
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