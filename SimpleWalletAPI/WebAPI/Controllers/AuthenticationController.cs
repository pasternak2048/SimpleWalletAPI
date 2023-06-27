using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Authentication;

namespace WebAPI.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;

        public AuthenticationController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }

        [HttpPost("register")] // POST: api/account/register?username=dave&password=pwd
        public async Task<ActionResult<AuthenticationResponce>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.UserName)) return BadRequest("Username is taken");

            var user = _mapper.Map<AppUser>(registerDto);

            user.UserName = registerDto.UserName.ToLower();

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Client");

            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            var userRoles = await _userManager.GetRolesAsync(user);

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.UserName, user.FirstName, user.LastName, user.Email, userRoles.FirstOrDefault());

            return new AuthenticationResponce
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = userRoles.FirstOrDefault(),
                Token = token
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponce>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == loginDto.UserName);

            if (user == null) return Unauthorized("Invalid username");

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result) return Unauthorized("Invalid password");

            var userRoles = await _userManager.GetRolesAsync(user);

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.UserName, user.FirstName, user.LastName, user.Email, userRoles.FirstOrDefault());

            return new AuthenticationResponce
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = userRoles.FirstOrDefault(),
                Token = token
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
