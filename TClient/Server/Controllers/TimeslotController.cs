using System;
using System.Threading.Tasks;
using Application.UseCases.CreateTimeslot;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class TimeslotController : ApiController
    {
        public TimeslotController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("create")]
        [Authorize(Policy = Policies.IsTeacher)]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateTimeSlot(Guid teacherId)
        {
            var claims = HttpContext.User.Identity;
            await _mediator.Send(new CreateTimeslotCommand(new Guid("5f138154-2c65-4be8-89f6-34c8b1d5cb87"), new Guid("7d4a08f7-8a38-48f0-953f-c180d7577f95")
                                                           ,"Bla bla", new DateTime(2020, 02, 14, 20, 00, 00), new DateTime(2020, 02, 14, 23, 00, 00)));
            return Ok();
        }
    }
}