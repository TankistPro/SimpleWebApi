using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using WebApi.Context;
using WebApi.Interfaces;
using WebApi.Interfaces.Repositories;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataBaseContext _context;
        private readonly IBaseRepository<User> _userRepository;

        public UserRepository(DataBaseContext context, IBaseRepository<User> userRepository) : base(context)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public bool IsUserExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public ClaimsIdentity GetIndentity(string email)
        {
            var user = GetUserByEmail(email);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultNameClaimType);

                return claimsIdentity;
            }

            return null;
        }
    }
}
