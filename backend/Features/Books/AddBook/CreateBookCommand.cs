using LibraryBackend.Database;
using MediatR;

namespace LibraryBackend.Features.Books {
    /// <summary>
    /// Модель данных, требуемых для создания книги в базе
    /// </summary>
    public class CreateBookCommand : IRequest<Book>
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required Guid? AuthorId { get; set; }
        public required string Publisher { get; set; }
        public DateOnly? PublishDate { get; set; }
        public Guid? GenreId { get; set; }
        public Guid? BbkId { get; set; }
        public Guid? UdkId { get; set; }
    }
}