using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Database {

    /// <summary>
    /// Класс, описывающий жанры книг
    /// </summary>
    public class Genre {
        [Key]
        public GUID GenreId { get; set; }
        public string GenreName { get; set; }
    }
}