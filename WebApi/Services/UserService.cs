using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Context;
using WebApi.Interfaces;
using WebApi.Interfaces.Repositories;
using WebApi.Interfaces.Services;
using WebApi.ModelDto;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapping, IUserRepository userRepository)
        {
            _mapper = mapping;
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();

            return _mapper.Map<List<UserDto>>(users);
        }

        public UserDto GetUser(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var user = _userRepository.GetById((int)id);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> RegistrationUser(RegistrationUserDto user)
        {
            try
            {
                bool isUserExsist = _userRepository.IsUserExists(user.Email);

                if (isUserExsist)
                {
                    return false;
                }

                var userMap = _mapper.Map<User>(user);

                var status = await _userRepository.Add(userMap);

                return status;
            } 
            catch
            {
                return false;
            }
        }
        public ServerResponseDto<TokensDto> LoginUser(LoginUserDto user)
        {
            var identity = _userRepository.GetIndentity(user.Email);
            bool status = false;
            string message = null;
            TokensDto tokens = new TokensDto();

            if (identity != null)
            {
                status = true;
                tokens = GenerateToken(identity);
            } 
            else
            {
                message = "Пользователь не найден";
            }

            return new ServerResponseDto<TokensDto>()
            {
                status = status,
                message = message,
                response = status ? tokens : null
            };
        }

        #region privateMethods
        private TokensDto GenerateToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires:now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(
                    AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256)
                );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokensDto()
            {
                access_toke = encodedJwt
            };
        }
        #endregion
    }
}
