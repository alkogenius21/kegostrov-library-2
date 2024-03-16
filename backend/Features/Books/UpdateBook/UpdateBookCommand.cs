using LibraryBackend.Database;
using MediatR;

namespace LibraryBackend.Features.Books {
    /// <summary>
    /// Модель предствления данных для изменения данных о книге
    /// </summary>
    public class UpdateBookCommand : IRequest<Book>
    {
        public Guid BookId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required Guid? AuthorId { get; set; }
        public required string Publisher { get; set; }
        public DateOnly? PublishDate { get; set; }
        public Guid? GenreId { get; set; }
        public Guid? BbkId { get; set; }
        public Guid? UdkId { get; set; }
        public DateTime? UploadDate { get; set; }
    }
}