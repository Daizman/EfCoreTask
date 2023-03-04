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
        
        // InitDbNormalData(modelBuilder);
        InitDbDummyData(modelBuilder);
    }

    private void InitDbNormalData(ModelBuilder modelBuilder)
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

    private void InitDbDummyData(ModelBuilder modelBuilder)
    {
        const int authorsCount = 10;
        const int publishersCount = 5;
        const int genresCount = 12;

        InitAuthors(modelBuilder, authorsCount);
        InitPublishers(modelBuilder, publishersCount);
        InitGenres(modelBuilder, genresCount);
        InitBooks(modelBuilder, authorsCount, publishersCount, genresCount);
    }

    private void InitAuthors(ModelBuilder modelBuilder, int authorsCount)
    {
        var authors = new Author[authorsCount];

         for (int i = 1; i <= authorsCount; i++)
        {
            authors[i - 1] = new()
            {
                Id = i,
                Fio = $"Author_{i}"
            };
        }

        modelBuilder.Entity<Author>().HasData(authors);
   }

    private void InitPublishers(ModelBuilder modelBuilder, int publishersCount)
    {
        var publishers = new Publisher[publishersCount];

        for (int i = 1; i <= publishersCount; i++)
        {
            publishers[i - 1] = new()
            {
                Id = i,
                Name = $"Publisher_{i}"
            };
        }

        modelBuilder.Entity<Publisher>().HasData(publishers);
   }

    private void InitGenres(ModelBuilder modelBuilder, int genresCount)
    {
        var genres = new Genre[genresCount];

        for (int i = 1; i <= genresCount; i++)
        {
            genres[i - 1] = new()
            {
                Id = i,
                Name = $"Genre_{i}"
            };
        }

        modelBuilder.Entity<Genre>().HasData(genres); 
   }

    private void InitBooks(ModelBuilder modelBuilder, int authorsCount, int publishersCount, int genresCount)
    {
        const int bookPerGenre = 4;
        var books = new Book[bookPerGenre * genresCount];
        Random random = new();

        for (int i = 1; i <= genresCount; i++)
        {
            for (int j = 1; j <= bookPerGenre; j++)
            {
                books[(i - 1) * (j - 1)] = new()
                {
                    Id = i * j,
                    Title = $"Book_${i * j}",
                    GenreId = i,
                    PublisherId = random.Next(1, publishersCount + 1)
                };
            }
        }

        modelBuilder.Entity<Book>()
                    .HasMany(book => book.Authors)
                    .WithMany(author => author.Books)
                    .UsingEntity(bookAuthor => bookAuthor.HasData(
                        Enumerable.Range(1, bookPerGenre * genresCount)
                                  .Select(index => new 
                                      { 
                                          AuthorsId = random.Next(1, authorsCount + 1), 
                                          BooksId = index 
                                      })
                                  .ToArray()))
                    .HasData(books); 
    }
}