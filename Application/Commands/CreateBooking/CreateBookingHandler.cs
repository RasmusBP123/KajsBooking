using Application.Common.Base;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            var duration = request.To - request.From;
            var booking = new Booking
            {
                From = request.From,
                To = request.To,
                Type = new BookingType
                {
                    Duration = duration
                }
            };

            var timeslot = _dbContext.Timeslots.Include(t => t.Bookings).FirstOrDefault(timeslot => timeslot.Id == request.TimeslotId);

            if(timeslot.IsBookingsOverLapping(booking))
            {
                timeslot.CreateBooking(booking);
                return Task.FromResult(_dbContext.SaveChanges());
            }

            return Task.FromResult(false);
        }

        public bool IsBookingsOverLapping(Timeslot timeslot, Booking newBooking)
        {
            var result = timeslot.Bookings.All(existingBooking => newBooking.From > existingBooking.To || newBooking.To < existingBooking.From);
            return result;
        }
    }
}
