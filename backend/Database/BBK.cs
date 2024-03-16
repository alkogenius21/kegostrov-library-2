using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryBackend.Database {
    /// <summary>
    /// Модель, описывающая ББК код
    /// </summary>
    public class BBK {
        /// <summary>
        /// Уникальный идентификатор ББК
        /// </summary>
        [Key]
        public Guid BbkId { get; set; }
        /// <summary>
        /// Текстовое значение ББК
        /// </summary>
        public required string Type { get; set; }
        /// <summary>
        /// Код ББК
        /// </summary>
        public required string Code { get; set; }
    }
}