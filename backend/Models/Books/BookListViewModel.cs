using backend.Database;

namespace backend.Models.Books {
    public class BookListViewModel
    {
        public required IEnumerable<Book> Books { get; set; }
    }
}