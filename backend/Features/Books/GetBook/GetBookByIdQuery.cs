using LibraryBackend.Database;
using MediatR;

namespace LibraryBackend.Features.Books {
    /// <summary>
    /// Id книги в параметрах запроса
    /// </summary>
    public class GetBookByIdQuery : IRequest<Book>
    {
        /// <summary>
        /// Идентификатор книги
        /// </summary>
        public Guid BookId { get; set; }
    }
}