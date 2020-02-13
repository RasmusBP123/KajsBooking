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

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateTimeSlot(Guid teacherId)
        {
            await _mediator.Send(new CreateTimeslotCommand(new Guid("5f138154-2c65-4be8-89f6-34c8b1d5cb87"), new Guid("7d4a08f7-8a38-48f0-953f-c180d7577f95")
                                                           ,"Bla bla", new DateTime(2020, 02, 06), new DateTime(2020, 02, 06)));
            return Ok();
        }
    }
}