using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Database {
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
            {
            }
            public DbSet<Book> Books { get; set; }
            public DbSet<Genre> Genres { get; set; }
            public DbSet<BBK> BBKS { get; set; }
            public DbSet<UDK> UDKS { get; set; }
            public DbSet<LibraryCard> LibraryCards { get; set; }
            public DbSet<NewsItem> NewsItems { get; set; }
    }
}