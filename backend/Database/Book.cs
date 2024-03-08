using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Database {
    /// <summary>
    /// Модель, описывающая книгу
    /// </summary>
    public class Book {
        [Key]
        public GUID BookId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Author { get; set; }
        public required string Publisher { get; set; }
        public DateOnly? PublishDate { get; set; }
        public Genre Genre { get; set; }

    }
}