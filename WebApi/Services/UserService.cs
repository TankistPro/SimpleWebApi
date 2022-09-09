using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Context;
using WebApi.Interfaces;
using WebApi.ModelDto;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;

        public UserService(DataBaseContext context, IMapper mapping)
        {
            _mapper = mapping;
            _userRepository = new UserRepository(context);
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
