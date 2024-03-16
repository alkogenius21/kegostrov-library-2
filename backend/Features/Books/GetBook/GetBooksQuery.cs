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
    }
}