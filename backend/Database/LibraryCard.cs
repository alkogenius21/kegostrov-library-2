using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Database {
    /// <summary>
    /// Модель, описывающая библиотечную карточку
    /// </summary>
    public class LibraryCard
    {
        /// <summary>
        /// Модель, описывающая статус в записи карточки
        /// </summary>
        public enum BookStatus
        {
            /// <summary>
            /// Зарзервировано
            /// </summary>
            Reserved,
            /// <summary>
            /// Выдано
            /// </summary>
            Issued,
            /// <summary>
            /// Возвращено
            /// </summary>
            Returned,
            /// <summary>
            /// Бронь отменена
            /// </summary>
            Canceled
        }
        /// <summary>
        /// Идентфикатор записи карточки
        /// </summary>
        [Key]
        public Guid LibraryCardId { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public required AppUser AppUser { get; set; }
        /// <summary>
        /// Ссылка на книгу
        /// </summary>
        public required Book Book { get; set; }
        /// <summary>
        /// Дата бронирования книги
        /// </summary>
        public DateTime DateReserved { get; set; }
        /// <summary>
        /// Дата взятия книги на дом
        /// </summary>
        public DateTime? DateTaken { get; set; }
        /// <summary>
        /// Дата возвращения книги
        /// </summary>
        public DateTime? DateReturned { get; set; }
        /// <summary>
        /// Текущий статус записи карточки
        /// </summary>
        public BookStatus Status { get; set; }

        public override string ToString()
        {
            return $"{Book.Title} - {AppUser.UserName} ({Status})";
        }
    }
}