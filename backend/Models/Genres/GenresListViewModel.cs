using backend.Database;

namespace backend.Models.Genres {
    public class GenresListViewModel {
        public required IEnumerable<Genre> Genres { get; set; }
    }
}