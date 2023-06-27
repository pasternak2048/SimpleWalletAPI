﻿using Application.Features.CardFeatures.CreateCard;
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
        public async Task<ActionResult<CreateCardResponse>> CreateCard()
        {
            var result = await _mediator.Send(new CreateCardRequest());
            return Ok(result);
        }
    }
}