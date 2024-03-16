using MediatR;
using LibraryBackend.Models.Genres;

namespace LibraryBackend.Features.Genres {
    public class GetGenresQuery : IRequest<GenresListViewModel> {
        public int Page { get; set; }
    }
}