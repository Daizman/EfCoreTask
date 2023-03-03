using Microsoft.EntityFrameworkCore;

public class Context : DbContext 
{
    private readonly string _connectionString;
    
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public Context(DbContextOptions<Context> options, IConfiguration configuration) : base(options)
    {
        var connectionStringInConfiguration = configuration.GetConnectionString("SqliteDb");
        if (connectionStringInConfiguration is null)
        {
            throw new ArgumentException("Incorrect connection string");    
        }
        _connectionString = connectionStringInConfiguration;
        Database.EnsureCreated();    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasIndex(author => author.Id).IsUnique();
        modelBuilder.Entity<Publisher>().HasIndex(publisher => publisher.Id).IsUnique();
        modelBuilder.Entity<Book>().HasIndex(book => book.Id).IsUnique();
        modelBuilder.Entity<Genre>().HasIndex(genre => genre.Id).IsUnique();
        
        InitDb(modelBuilder);
    }

    private void InitDb(ModelBuilder modelBuilder)
    {
        Author a1 = new() { Id = 1, Fio = "А.С.Пушкин" };
        Author a2 = new() { Id = 2, Fio = "Ф.М.Достоевский" };

        Publisher p1 = new() { Id = 1, Name = "Азбука" };
        Publisher p2 = new() { Id = 2, Name = "Эксмо" };

        Genre g1 = new() { Id = 1, Name = "Детектив" };
        Genre g2 = new() { Id = 2, Name = "Роман" };
        Genre g3 = new() { Id = 3, Name = "Ужасы" };

        
        modelBuilder.Entity<Author>().HasData(new Author[] { a1, a2 });

        modelBuilder.Entity<Publisher>().HasData(new Publisher[] { p1, p2 });

        modelBuilder.Entity<Genre>().HasData(new Genre[] { g1, g2, g3 });

        Book b1 = new() 
        { 
            Id = 1,
            GenreId = g2.Id,
            PublisherId = p1.Id,
            Title = "Евгений Онегин"
        };

        modelBuilder.Entity<Book>()
                    .HasMany(b => b.Authors)
                    .WithMany(a => a.Books)
                    .UsingEntity(j => j.HasData(new { AuthorsId = a1.Id, BooksId = b1.Id }))
                    .HasData(b1);
    }
}