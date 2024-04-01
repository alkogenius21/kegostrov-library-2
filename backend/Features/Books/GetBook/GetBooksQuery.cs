using MediatR;
using LibraryBackend.Models.Books;

namespace LibraryBackend.Features.Books {
    /// <summary>
    /// Модель, описывающая пагинацию книг
    /// </summary>
    public class GetBooksQuery : IRequest<BookListViewModel>
    {
        /// <summary>
        /// Страница
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Размер страницы
        /// </summary>
        public int PageSize { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public DateOnly? PublishDate { get; set; }
    }
}