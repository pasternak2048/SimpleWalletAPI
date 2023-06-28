using Application.Common.Interfaces;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICurrentUserService _currentUserService;
        private readonly IBonusService _bonusService;


        public UserController(ICurrentUserService currentUserService, UserManager<AppUser> userManager, IBonusService bonusService)
        {
            _currentUserService = currentUserService;
            _userManager = userManager;
            _bonusService = bonusService;
        }

        [Authorize]
        [HttpPost("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var userId = _currentUserService.UserId;
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.Id == _currentUserService.UserId);

            var userResult = new UserDto()
            {
                Id = user!.Id,
                FirstName = user!.FirstName!,
                LastName = user!.LastName!,
                Email = user!.Email!,
                Bonuses = _bonusService.GetBonuses(),
            };
            
            return Ok(userResult);
        }
    }
}
