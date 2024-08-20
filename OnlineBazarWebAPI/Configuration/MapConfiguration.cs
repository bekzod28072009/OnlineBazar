using AutoMapper;
using Bazar.Domain.Entities.Users;
using Bazar.Service.DTOs.Users;

namespace OnlineBazarWebAPI.Configuration
{
    public class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            // User for Shopping
            CreateMap<User, UseerForCreateDto>().ReverseMap();
            CreateMap<User, UserForUpdateDto>().ReverseMap();
            CreateMap<User, UserForViewDto>().ReverseMap();
            CreateMap<User, UsersOrder>().ReverseMap();


        }
    }
}
