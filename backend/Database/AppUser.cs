using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Database {
    /// <summary>
    /// Модель, описывающая пользователя
    /// </summary>
    public class AppUser : IdentityUser {
        public string? FirstName { get; set; }
        public string? SecondNane {get; set; }
        public string? LastName { get; set; }
        public DateOnly? BirthDate { get; set; }
        public bool IsActivated { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LibraryCardNumber { get; set; }

        /// <summary>
        /// Добавляет сгенерированный номер карточки к пользователю
        /// </summary>
        public AppUser()
        {
            LibraryCardNumber = GenerateCardNumber();
        }

        /// <summary>
        /// Генерирует новый номер карточки для пользователя
        /// </summary>
        /// <returns>10-ти значное число</returns>
        private long GenerateCardNumber()
        {
            Random random = new Random();
            return (long)(random.NextDouble() * 9000000000) + 1000000000;
        }
    } 
}