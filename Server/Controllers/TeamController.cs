using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.AttachStudentToTeam;
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

        [HttpPost("{teamId}/students")]
        public async Task<IActionResult> AttachStudentsToTeam([FromRoute] Guid teamId)
        {
            var students = new List<Student>
            {
                new Student
                {
                    Id = new Guid("1ced3047-cffb-4d3b-810b-48692e228459"),
                    Name = "Rasmus Bak"
                },
                new Student
                {
                    Id = new Guid("a50ceca0-1a34-4d7e-bbec-23f8986257ec"),
                    Name = "Brian Nielsen"
                }
            };
            await _mediator.Send(new AttachStudentToTeamCommand(new Guid("bacabc7d-30da-4d56-cba2-08d7b0a139f1"), students));
            return Ok();
        }
    }
}