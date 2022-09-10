﻿using System.Linq;
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

        public bool IsUserExists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}
