using System.Linq;
using WebApi.Context;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        private readonly DataBaseContext _context;
        private readonly IBaseRepository<User> _userRepository;

        public UserRepository(DataBaseContext context) : base(context)
        {
            _context = context;
            _userRepository = new BaseRepository<User>(context);
        }

        public bool IsUserExists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}
