using backend.Database;
using MediatR;

namespace backend.Features.Books {
    /// <summary>
    /// Модель предствления данных для изменения данных о книге
    /// </summary>
    public class PutBookCommand : IRequest<Book>
    {
        public Guid BookId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Author { get; set; }
        public required string Publisher { get; set; }
        public DateOnly? PublishDate { get; set; }
        public Guid? GenreId { get; set; }
        public Guid? BbkId { get; set; }
        public Guid? UdkId { get; set; }
        public DateTime? UploadDate { get; set; }
    }
}