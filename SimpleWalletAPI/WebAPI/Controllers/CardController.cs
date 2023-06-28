using Application.Features.CardFeatures.CreateCard;
using Application.Features.CardFeatures.GetCard;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CardController : BaseApiController
    {
        private readonly IMediator _mediator;

        public CardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("CreateCard")]
        public async Task<ActionResult<CreateCardResponse>> CreateCard(CreateCardRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetCard")]
        public async Task<ActionResult<GetCardResponse>> GetCard([FromQuery]GetCardRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
