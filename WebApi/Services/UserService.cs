using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Context;
using WebApi.Interfaces;
using WebApi.Interfaces.Repositories;
using WebApi.Interfaces.Services;
using WebApi.ModelDto;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(DataBaseContext context, IMapper mapping, IUserRepository userRepository)
        {
            _mapper = mapping;
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();

            return _mapper.Map<List<UserDto>>(users);
        }

        public UserDto GetUser(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var user = _userRepository.GetById((int)id);

            return _mapper.Map<UserDto>(user);
        }
    }
}
