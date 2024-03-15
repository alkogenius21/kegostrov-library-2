using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Database {
    /// <summary>
    /// Модель, описывающая книгу
    /// </summary>
    public class Book {
        /// <summary>
        /// Уникальный идентификатор книги
        /// </summary>
        [Key]
        public Guid BookId { get; set; }
        /// <summary>
        /// Название книги
        /// </summary>
        public required string Title { get; set; }
        /// <summary>
        /// Описание книги
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Автор книги
        /// </summary>
        public required string Author { get; set; }
        /// <summary>
        /// Издательство книги
        /// </summary>
        public required string Publisher { get; set; }
        /// <summary>
        /// Дата публикации книги
        /// </summary>
        public DateOnly? PublishDate { get; set; }
        /// <summary>
        /// Жанр книги
        /// </summary>
        public Genre? Genre { get; set; }
        /// <summary>
        /// Код идентификатора книги в ББК
        /// </summary>
        public BBK? BBK { get; set; }
        /// <summary>
        /// Код идентификатора книги в УДК
        /// </summary>
        public UDK? UDK { get; set; }
        /// <summary>
        /// Дата загрузки в базу данных
        /// </summary>
        public DateOnly? UploadDate { get; set; }

        /// <summary>
        /// Метод который возвращает информацию об экземпляре класса Book
        /// </summary>
        public override string ToString() {
            return $"{Title} - {Author}";
        }
    }
}