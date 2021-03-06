﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CommandUseCases.AttachTeachersToCalendar;
using Application.Queries.GetAllCalendars;
using Application.QueryUseCases.GetCalendarForTeam;
using Application.UseCases.CreateCalendar;
using Domain.Entities;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class CalendarController : ApiController
    {
        public CalendarController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllCalendars()
        {
            var calendars = await _mediator.Send(new GetAllCalendarsQuery());
            return Ok(calendars);
        }

        [HttpGet("{calendarId}")]
        public async Task<IActionResult> GetCalendarForTeam([FromRoute] Guid calendarId)
        {
            var result = await _mediator.Send(new GetCalendarForTeamQuery(calendarId));
            return Ok(result);
        }

        [HttpPost("create")]
        [Authorize(Policy = Policies.IsTeacher)]

        public async Task<IActionResult> CreateCalendar()
        {
            await _mediator.Send(new CreateCalendarCommand("My first calendar", new Guid("5f138154-2c65-4be8-89f6-34c8b1d5cb87")));
            return Ok();
        }

        [HttpPost("{calendarId}/teachers")]
        [Authorize(Policy = Policies.IsTeacher)]
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