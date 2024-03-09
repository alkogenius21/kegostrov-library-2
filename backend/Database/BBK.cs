using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Database {
    /// <summary>
    /// Модель, описывающая ББК код
    /// </summary>
    public class BBK {
        [Key]
        public Guid BbkId { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
    }
}