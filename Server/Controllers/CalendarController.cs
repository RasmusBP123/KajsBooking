using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.CreateCalendar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class CalendarController : ApiController
    {
        public CalendarController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCalendar()
        {
            await _mediator.Send(new CreateCalendarCommand("My first calendar", new Guid("5f138154-2c65-4be8-89f6-34c8b1d5cb87")));
            return Ok();
        }
    }
}