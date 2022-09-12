using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public bool IsUserExists(string email);
        public User GetUserByEmail(string email);
    }
}
