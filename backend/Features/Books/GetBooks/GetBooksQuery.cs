using MediatR;
using backend.Models.Books;

namespace backend.Features.Books {
    /// <summary>
    /// Модель, описывающая пагинацию книг
    /// </summary>
    public class GetBooksQuery : IRequest<BookListViewModel>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}