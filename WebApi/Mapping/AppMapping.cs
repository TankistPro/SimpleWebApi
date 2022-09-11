using AutoMapper;
using WebApi.Models;
using WebApi.ModelDto;

namespace WebApi.Mapping
{
    public class AppMapping : Profile
    {
        public AppMapping()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<RegistrationUserDto, User>().ReverseMap();
        }
    }
}
