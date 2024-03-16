namespace LibraryBackend {
    /// <summary>
    /// Класс Program служит точкой входа в приложение.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Основная точка входа в приложение.
        /// </summary>
        /// <param name="args">Массив аргументов командной строки, переданных в приложение.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Создает построитель хоста для настройки сервисов приложения и среды хостинга.
        /// </summary>
        /// <param name="args">Массив аргументов командной строки, переданных в приложение.</param>
        /// <returns>Экземпляр IHostBuilder, представляющий построитель хоста, настроенный с настройками по умолчанию.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}