﻿using System;
using Microsoft.AspNetCore.Mvc;
using ScoreFight.Domain;
using ScoreFight.Domain.Bets.Command;

namespace ScoreFight.Api.Controllers
{
    [Route("api/matches/{matchId}/bets")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Set user bet for given match
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/matches/{matchId}/bets
        ///     {   "matchId": "081ede0d-2fdf-4d0b-9b8e-6cc256deacd0",
        ///         "playerId": "C9888D13-E9DA-454A-86A2-62BEC0302F2D",
        ///         "matchResults": "2",
        ///         "pointsBet": 100
        ///     }
        /// 
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="202">Bet correctly inserted</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Given match was not found</response>
        /// 
        [HttpPost]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Bet([FromBody] SetBetCommand command)
        {
            try
            {
                _mediator.Command(command);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }

        }

        /// <summary>
        /// Set user bet for given match
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/matches/{matchId}/bets
        ///     {   "matchId": "081ede0d-2fdf-4d0b-9b8e-6cc256deacd0",
        ///         "playerId": "C9888D13-E9DA-454A-86A2-62BEC0302F2D",
        ///         "matchResults": "2",
        ///         "pointsBet": 100
        ///     }
        /// 
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="202">Bet correctly updated</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Given bet was not found</response>
        /// 
        [HttpPut]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Bet([FromBody] UpdateBetCommand command)
        {
            try
            {
                _mediator.Command(command);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }

        }

        /// <summary>
        /// Set user bet for given match
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/matches/{matchId}/bets
        ///     {
        ///         "matchId": "081ede0d-2fdf-4d0b-9b8e-6cc256deacd0",
        ///         "playerId": "C9888D13-E9DA-454A-86A2-62BEC0302F2D"
        ///     }
        /// 
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="202">Bet correctly deleted</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Given bet was not found</response>
        /// 
        [HttpDelete]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Bet([FromBody] CancelBetCommand command)
        {
            try
            {
                _mediator.Command(command);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }

        }

    }
}