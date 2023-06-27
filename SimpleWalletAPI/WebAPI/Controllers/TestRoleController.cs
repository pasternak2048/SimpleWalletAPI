using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    public class TestRoleController : BaseApiController
    {
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
    }
}
