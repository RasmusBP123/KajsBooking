using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CommandUseCases.AttachTeachersToCalendar;
using Application.UseCases.CreateCalendar;
using Domain.Entities;
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

        [HttpPost("{calendarId}/teachers")]
        public async Task<IActionResult> AttachTeachersToCalendar([FromRoute] Guid calendarId)
        {
            var teachers = new List<Teacher>()
            {
                new Teacher()
                {
                    Id = new Guid("8de6d47f-9960-4bc2-adfd-7d1b02c836ba"),
                    Name = "Simon"
                },

            };
            await _mediator.Send(new AttachTeachersToCalendarCommand(calendarId, teachers));
            return Ok();
        }
    }
}