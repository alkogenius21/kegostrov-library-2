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
            Reserved,
            Issued,
            Returned,
            Canceled
        }

        [Key]
        public Guid LibraryCardId { get; set; }
        public AppUser AppUser { get; set; }
        public Book Book { get; set; }
        public DateTime DateReserved { get; set; }
        public DateTime? DateTaken { get; set; }
        public DateTime? DateReturned { get; set; }
        public BookStatus Status { get; set; }

        public override string ToString()
        {
            return $"{Book.Title} - {AppUser.UserName} ({Status})";
        }
    }
}