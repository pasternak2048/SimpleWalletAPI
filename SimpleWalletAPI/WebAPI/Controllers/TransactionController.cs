using Application.Common.Interfaces;
using Application.Features.TransactionFeatures.CreateTransaction;
using Application.Features.TransactionFeatures.GetTransaction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class TransactionController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;

        public TransactionController(IMediator mediator, ICurrentUserService currentUserService)
        {
            _mediator = mediator;
            _currentUserService = currentUserService;
        }

        [Authorize]
        [HttpPost("CreateTransaction")]
        public async Task<ActionResult<CreateTransactionResponse>> CreateTransaction(CreateTransactionRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetTransaction")]
        public async Task<ActionResult<GetTransactionResponse>> GetTransaction([FromQuery]GetTransactionRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            if(result.CreatedById != _currentUserService.UserId)
            {
                return StatusCode(403);
            }
            return Ok(result);
        }
    }
}
