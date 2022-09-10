using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.ModelDto;

namespace WebApi.Interfaces.Services
{
    public interface IUserService
    {
        public Task<List<UserDto>> GetAllUsers();
        public UserDto GetUser(int? id);
    }
}
