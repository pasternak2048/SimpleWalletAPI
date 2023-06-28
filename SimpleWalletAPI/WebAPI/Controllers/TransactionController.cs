using Application.Common.Interfaces;
using Application.Features.TransactionFeatures.CreateTransaction;
using Application.Features.TransactionFeatures.GetTransaction;
using Application.Features.TransactionFeatures.GetTransactions;
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
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetTransactions")]
        public async Task<ActionResult<List<GetTransactionsResponse>>> GetTransactions([FromQuery] GetTransactionsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }
    }
}
