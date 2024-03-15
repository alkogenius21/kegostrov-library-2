using MediatR;

namespace backend.Features.Books {
    /// <summary>
    /// Команда с Id книги
    /// </summary>
    public class DeleteBookCommand : IRequest<Unit>
    {
        public Guid BookId { get; set; }
    }
}