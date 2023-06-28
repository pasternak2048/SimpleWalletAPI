using Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    public class TestRoleController : BaseApiController
    {
        private readonly IBonusService _bonusService;

        public TestRoleController(IBonusService bonusService)
        {
            _bonusService = bonusService;
        }

        [Authorize]
        [HttpGet("TestAuthorize")]
        public async Task<ActionResult> TestAuthorize()
        {
            return Ok();
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("TestAuthorizeRoleAdminUser")]
        public async Task<ActionResult> TestAuthorizeRoleAdminUser()
        {
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("TestAuthorizeRoleAdmin")]
        public async Task<ActionResult> TestAuthorizeRoleAdmin()
        {
            return Ok();
        }

        [Authorize(Roles = "User")]
        [HttpGet("TestAuthorizeRoleUser")]
        public async Task<ActionResult> TestAuthorizeRoleUser()
        {
            return Ok();
        }

        [HttpGet("TestSeason")]
        public async Task<ActionResult<double>> GetDayOfSeason()
        {
            return _bonusService.GetBonuses();
        }
    }
}
