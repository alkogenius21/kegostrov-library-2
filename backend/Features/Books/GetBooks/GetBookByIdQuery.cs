using backend.Database;
using MediatR;

namespace backend.Features.Books {
    /// <summary>
    /// Id книги в параметрах запроса
    /// </summary>
    public class GetBookByIdQuery : IRequest<Book>
    {
        public Guid BookId { get; set; }
    }
}