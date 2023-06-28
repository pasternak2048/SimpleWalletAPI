using Application.Features.TransactionFeatures.GetViewTransaction;
using Application.Features.TransactionFeatures.GetViewTransactions;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(IMediator mediator, UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [HttpGet("GetTransaction")]
        public async Task<ActionResult<GetViewTransactionResponse>> GetTransaction([FromQuery] GetViewTransactionRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            if (result == null) return StatusCode(404);
            return Ok(result);
        }


        [HttpGet("GetTransactions")]
        public async Task<ActionResult<List<GetViewTransactionsResponse>>> GetTransactions([FromQuery] GetViewTransactionsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<UserAdminDto>> GetUser(Guid userId, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null) return StatusCode(404);

            var result = new UserAdminDto()
            {
                Id = user.Id,
                UserName = user.UserName!,
                FirstName = user.FirstName!,
                LastName = user.LastName!,
                Email = user.Email!
            };

            return Ok(result);
        }
    }
}
