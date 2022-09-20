using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Interfaces;
using WebApi.Interfaces.Services;
using WebApi.ModelDto;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userSerive;

        public UserController(IUserService userService)
        {
            _userSerive = userService;
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        [HttpGet]
        public async Task<List<UserDto>> GetAllUsers()
        {
            return await _userSerive.GetAllUsers();
        }

        /// <summary>
        /// Получение пользователя по ID
        /// </summary>
        [HttpGet("{id}")]
        public UserDto GetUser(int? id)
        {
            return _userSerive.GetUser(id);
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> RegistrationUser([FromBody] RegistrationUserDto user) 
        { 
            var status = await _userSerive.RegistrationUser(user);

            return Ok(status); 
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult<ServerResponseDto<TokensDto>> Login([FromBody] LoginUserDto user)
        {
            if (user == null || user.Email == null || user.Password == null)
            {
                return BadRequest("Incorrect body data");
            }

            var response = _userSerive.LoginUser(user);

            return response;
        }
    }
}
