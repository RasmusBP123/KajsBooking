using Application.Common.Base;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CreateTimeslot
{
    public class CreateTimeSlotHandler : BaseContext, IRequestHandler<CreateTimeslotCommand, bool>
    {
        public CreateTimeSlotHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Task<bool> Handle(CreateTimeslotCommand request, CancellationToken cancellationToken)
        {
            var teacher = _dbContext.Teachers.FirstOrDefault(t => t.Id == request.TeacherId);
            var calendar = _dbContext.Calendars.FirstOrDefault(cal => cal.Id == request.CalendarId);
            var timeslotsWhereTeacherIsPresent = _dbContext.Timeslots.Where(timeslot => timeslot.Teacher.Id == teacher.Id).ToList();

            var timeSlot = new Timeslot
            {
                Description = request.Description,
                From = request.From,
                To = request.To,
                Calendar = calendar
            };

            if (timeSlot.IsTimeslotsOverlapping(timeslotsWhereTeacherIsPresent, timeSlot))
            {
                teacher.CreateTimeSlot(timeSlot);
                return Task.FromResult(_dbContext.SaveChanges());
            }

            return Task.FromResult(false);
        }
    }
}
