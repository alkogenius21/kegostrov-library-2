using MediatR;
using backend.Models.Genres;

namespace backend.Features.Genres {
    public class GetGenresQuery : IRequest<GenresListViewModel> {
        public int Page { get; set; }
    }
}