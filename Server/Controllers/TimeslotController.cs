using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.CreateTimeslot;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class TimeslotController : ApiController
    {
        public TimeslotController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("bla")]
        public IActionResult Test()
        {
            return Ok(new JsonResult("Bal"));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTimeSlot(Guid teacherId)
        {
            await _mediator.Send(new CreateTimeSlotCommand(new Guid("5f138154-2c65-4be8-89f6-34c8b1d5cb87"), "Bla bla", new DateTime(2020, 02, 06), new DateTime(2020, 02, 06)));
            return Ok();
        }
    }
}