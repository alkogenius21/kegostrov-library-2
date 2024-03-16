using LibraryBackend.Database;
using LibraryBackend.Models.Genres;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryBackend.Features.Genres {
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