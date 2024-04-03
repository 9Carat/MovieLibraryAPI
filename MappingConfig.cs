using AutoMapper;
using MovieLibraryAPI.Models;
using MovieLibraryAPI.Models.DTO;

namespace MovieLibraryAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        { 
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Movie, MovieCreateDTO>().ReverseMap();
            CreateMap<Movie, MovieUpdateDTO>().ReverseMap();
            CreateMap<Rating, RatingDTO>().ReverseMap();
            CreateMap<Rating, RatingCreateDTO>().ReverseMap();
            CreateMap<StreamingService, StreamingServiceDTO>().ReverseMap();
            CreateMap<StreamingService, StreamingServiceCreateDTO>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
        }
    }
}
