using System.ComponentModel.DataAnnotations;

namespace LibraryBackend.Database {
    /// <summary>
    /// Модель, описывающая УДК код
    /// </summary>
    public class UDK {
        /// <summary>
        /// Идентификатор УДК кода
        /// </summary>
        [Key]
        public Guid UdkId { get; set; }
        /// <summary>
        /// Текстовая расшифровка УДК кода
        /// </summary>
        public required string Type { get; set; }
        /// <summary>
        /// Код по справочнику УДК
        /// </summary>
        public required string Code { get; set; }
    }
}