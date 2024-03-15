using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Database {
    /// <summary>
    /// Контекст базы данных приложения
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="options">Парметры контекста БД</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
            {
            }
            /// <summary>
            /// Книги
            /// </summary>
            public DbSet<Book> Books { get; set; }
            /// <summary>
            /// Жанры книг
            /// </summary>
            public DbSet<Genre> Genres { get; set; }
            /// <summary>
            /// Справочник ББК
            /// </summary>
            public DbSet<BBK> BBKS { get; set; }
            /// <summary>
            /// Справочник УДК
            /// </summary>
            public DbSet<UDK> UDKS { get; set; }
            /// <summary>
            /// Библиотечная карта
            /// </summary>
            public DbSet<LibraryCard> LibraryCards { get; set; }
            /// <summary>
            /// Новости
            /// </summary>
            public DbSet<NewsItem> NewsItems { get; set; }
    }
}