using AutoMapper;
using WebApi.Models;
using WebApi.ModelDto;
using System.Collections.Generic;

namespace WebApi.Mapping
{
    public class AppMapping : Profile
    {
        public AppMapping()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
