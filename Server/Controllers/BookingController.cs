using System;
using System.Threading.Tasks;
using Application.UseCases.CreateBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class BookingController : ApiController
    {
        public BookingController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBooking()
        {
            await _mediator.Send(new CreateBookingCommand(new Guid("0c11b033-1d81-420b-0434-08d7b080202f"), new DateTime(2020, 02, 06), new DateTime(2020, 02, 06)));
            return Ok();
        }
    }
}