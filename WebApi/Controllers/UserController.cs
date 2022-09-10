using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Interfaces;
using WebApi.Interfaces.Services;
using WebApi.ModelDto;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userSerive;

        public UserController(DataBaseContext context, IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userSerive = userService;
        }

        [HttpGet]
        public async Task<List<UserDto>> GetAllUsers()
        {
            return await _userSerive.GetAllUsers();
        }

        [HttpGet("{id}")]
        public UserDto GetUser(int? id)
        {
            return _userSerive.GetUser(id);
        }
    }
}
