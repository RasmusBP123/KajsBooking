using Application.Common.Base;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CreateBooking
{
    public class CreateBookingHandler : BaseContext, IRequestHandler<CreateBookingCommand, bool>
    {
        public CreateBookingHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Task<bool> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = new Booking
            {
                From = request.From,
                To = request.To
            };

            var timeslot = _dbContext.Timeslots.FirstOrDefault(timeslot => timeslot.Id == request.TimeslotId);
            timeslot.CreateBooking(booking);

            return Task.FromResult(_dbContext.SaveChanges());
        }
    }
}
