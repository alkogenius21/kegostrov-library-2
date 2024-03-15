using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Database {

    /// <summary>
    /// Класс, описывающий жанры книг
    /// </summary>
    public class Genre {
        /// <summary>
        /// Идентификатор жанра
        /// </summary>
        [Key]
        public Guid GenreId { get; set; }
        /// <summary>
        /// Название жанра
        /// </summary>
        public required string GenreName { get; set; }
    }
}