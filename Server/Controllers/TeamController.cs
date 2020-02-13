using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.CreateTeam;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class TeamController : ApiController
    {
        public TeamController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTeam()
        {
            await _mediator.Send(new CreateTeamCommand("Programming 101", new Guid("5f138154-2c65-4be8-89f6-34c8b1d5cb87")));
            return Ok();
        }
    }
}