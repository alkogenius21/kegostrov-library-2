using LibraryBackend.Database;

namespace LibraryBackend.Models.Books {
    /// <summary>
    /// Модель представления списка книг
    /// </summary>
    public class BookListViewModel
    {
        /// <summary>
        /// Список книг
        /// </summary>
        public required IEnumerable<Book> Books { get; set; }
    }
}