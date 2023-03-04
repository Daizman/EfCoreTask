public record GetBookDto(string Title, List<BookAuthorDto> Authors, string GenreName, string PublisherName);

public record BookAuthorDto(string Fio);

public record PutBookDto(int Id, string Title, List<int> AuthorIds, int GenreId, int PublisherId);

public record PostBookDto(string Title, List<int> AuthorIds, int GenreId, int PublisherId);


public record GetAuthorDto(string Fio, List<AuthorBookDto> Books);

public record AuthorBookDto(string Title, string GenreName);

public record PutAuthorDto(int Id, string Fio, List<int> BookIds);

public record PostAuthorDto(string Fio);


public record GetPublisherDto(string Name);

public record PutPublisherDto(int Id, string Name);

public record PostPublisherDto(string Name);


public record GetGenreDto(string Name, List<GenreBookDto> Books);

public record GenreBookDto(string Title);

public record PutGenre(string Name);

public record PostGenre(string Name);
