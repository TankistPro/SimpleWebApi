using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public bool IsUserExists(string email);
        public User GetUserByEmail(string email);
        public ClaimsIdentity GetIndentity(string email);
    }
}
