using System.ComponentModel.DataAnnotations;

namespace LibraryBackend.Database {
    /// <summary>
    /// Модель, описывающая автора книги
    /// </summary>
    public class Author {
        /// <summary>
        /// Идентификатор автора 
        /// </summary>
        [Key]
        public Guid AuthorId { get; set; }
        /// <summary>
        /// Полное имя автора
        /// </summary>
        public required string LongName {get; set;}
        /// <summary>
        /// Короткое имя автора
        /// </summary>
        public required string ShortName {get; set; }

    }
}