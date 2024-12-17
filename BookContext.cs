using Microsoft.EntityFrameworkCore;
using LibraryApplication.Models;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; } // Add your DbSet properties here
}
