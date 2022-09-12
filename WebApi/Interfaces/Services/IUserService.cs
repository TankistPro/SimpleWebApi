using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.ModelDto;

namespace WebApi.Interfaces.Services
{
    public interface IUserService
    {
        public Task<List<UserDto>> GetAllUsers();
        public UserDto GetUser(int? id);
        public Task<bool> RegistrationUser(RegistrationUserDto user);
        public ServerResponseDto<TokensDto> LoginUser(LoginUserDto user);
    }
}
