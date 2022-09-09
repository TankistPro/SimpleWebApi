using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.ModelDto;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;

        public UserController(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<UserDto>> GetAllUsers()
        {   
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<User>, List<UserDto>>(users);
        }

        [HttpGet("{id}")]
        public UserDto GetUser(int? id)
        {
            var user = _context.Users.Find(id);

            return _mapper.Map<UserDto>(user);
        }

        #region Private Methods
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        #endregion
    }
}
