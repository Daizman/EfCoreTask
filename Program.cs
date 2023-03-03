using System.Reflection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options => 
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteDb"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "api");
        options.RoutePrefix = string.Empty;
    });
}

app.MapGet("/book", async (Context db) =>
{
    return await db.Books.AsNoTracking().ToListAsync();
});

app.MapPost("/book", async (Context db, Book book) => 
{
    await db.Books.AddAsync(book);
    await db.SaveChangesAsync();
});

app.MapGet("/books-genres", async (Context db) => 
{
    var booksGenres = await (from books in db.Books
                             join genres in db.Genres on books.GenreId equals genres.Id
                             select new BookGenreDto(books.Id, genres.Id, books.Title, genres.Name))
                      .ToListAsync();
    return booksGenres;
});

app.MapGet("/author", async (Context db) => 
{
    return await db.Authors.AsNoTracking().ToListAsync();
});

app.MapPost("/author", async (Context db, Author author) => 
{
    await db.Authors.AddAsync(author);
    await db.SaveChangesAsync();
});

app.MapGet("/publisher-top/{id}", async (Context db, int id) => 
{
    // toDo
});

app.Run();

