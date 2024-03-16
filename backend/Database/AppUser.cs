using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryBackend.Database {
    /// <summary>
    /// Модель, описывающая пользователя
    /// </summary>
    public class AppUser : IdentityUser {
        /// <summary>
        /// Имя
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string? SecondNane {get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateOnly? BirthDate { get; set; }
        /// <summary>
        /// Статус активации
        /// </summary>
        public bool IsActivated { get; set; }

        /// <summary>
        /// Номер Карточки Библиотечной карты
        /// </summary>
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