using backend.Database;
using MediatR;

namespace backend.Features.Books.GetBooks {
    public class GetBookByIdQuery : IRequest<Book>
    {
        public Guid BookId { get; set; }
    }
}