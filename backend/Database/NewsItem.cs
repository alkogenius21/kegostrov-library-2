using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryBackend.Database {
    /// <summary>
    /// Модель описывающая новости
    /// </summary>
    public class NewsItem {
        /// <summary>
        /// Идентификатор новости
        /// </summary>
        [Key]
        public Guid NewsItemId { get; set; }
        /// <summary>
        /// Название новости
        /// </summary>
        public required string Article { get; set; }
        /// <summary>
        /// Тело новости
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Автор новости
        /// </summary>
        public required AppUser Author { get; set; }
        /// <summary>
        /// Дата публикации новости
        /// </summary>
        public required DateOnly PublishDate { get; set; }
        /// <summary>
        /// Статус закрепления новости
        /// </summary>
        public bool? IsPinned { get; set; }
        /// <summary>
        /// Статус скрытия новости
        /// </summary>
        public bool? IsHidden { get; set; }
    }
}