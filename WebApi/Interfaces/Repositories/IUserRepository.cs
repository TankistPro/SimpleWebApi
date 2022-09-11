using WebApi.Models;

namespace WebApi.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public bool IsUserExists(string email);
    }
}
