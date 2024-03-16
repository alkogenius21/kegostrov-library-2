using LibraryBackend.Database;

namespace LibraryBackend.Models.Genres {

    /// <summary>
    /// Модель представления жанров
    /// </summary>
    public class GenresListViewModel {
        /// <summary>
        /// Список жанров
        /// </summary>
        public required IEnumerable<Genre> Genres { get; set; }
    }
}