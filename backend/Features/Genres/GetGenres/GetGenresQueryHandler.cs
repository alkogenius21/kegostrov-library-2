using backend.Database;
using backend.Models.Genres;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace backend.Features.Genres.GetGenres {
    public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, GenresListViewModel> {
        private readonly ApplicationDbContext _context;

        public GetGenresQueryHandler(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<GenresListViewModel> Handle(
            GetGenresQuery request,
            CancellationToken cancellationToken) {
                return new GenresListViewModel {
                    Genres = await _context.Genres.ToListAsync()
                };
            }
    }
}