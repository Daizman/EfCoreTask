using AutoMapper;

public class AutoMapperProfile : Profile 
{
    public AutoMapperProfile()
    {
        CreateMap<Book, GetBookDto>();
        CreateMap<PostBookDto, Book>();
        CreateMap<PutBookDto, Book>();

        CreateMap<Author, GetAuthorDto>();
        CreateMap<PostAuthorDto, Author>();
        CreateMap<PutAuthorDto, Author>();

        CreateMap<Publisher, GetPublisherDto>();
        CreateMap<PostPublisherDto, Publisher>();
        CreateMap<PutPublisherDto, Publisher>();

        CreateMap<Genre, GetGenreDto>(); 
        CreateMap<PostGenreDto,Genre>();
        CreateMap<PutGenreDto, Genre>();
    }
}