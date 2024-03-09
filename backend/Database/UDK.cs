using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Database {
    /// <summary>
    /// Модель, описывающая УДК код
    /// </summary>
    public class UDK {
        [Key]
        public Guid UdkId { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
    }
}