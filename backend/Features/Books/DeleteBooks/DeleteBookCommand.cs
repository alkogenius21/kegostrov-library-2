using MediatR;

namespace backend.Features.Books.DeleteBooks {
    public class DeleteBookCommand : IRequest<Unit>
    {
        public Guid BookId { get; set; }
    }
}