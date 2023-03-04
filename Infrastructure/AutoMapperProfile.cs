using AutoMapper;

public class AutoMapperProfile : Profile 
{
    public AutoMapperProfile()
    {
        CreateMap<Book, GetBookDto>()
            .ForMember(dto => dto.GenreName, book => book.MapFrom(b => b.Genre.Name))
            .ForMember(dto => dto.PublisherName, book => book.MapFrom(b => b.Publisher.Name))
            .ForMember(dto => dto.Authors, book => book.MapFrom(b => b.Authors));
    }
}