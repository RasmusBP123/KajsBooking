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

namespace Application.UseCases.CreateCalendar
{
    public class CreateCalendarHandler : BaseContext, IRequestHandler<CreateCalendarCommand, bool>
    {
        public CreateCalendarHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Task<bool> Handle(CreateCalendarCommand request, CancellationToken cancellationToken)
        {
            var teacher = _dbContext.Teachers.FirstOrDefault(t => t.Id == request.TeacherId);   

            var calendar = new Calendar
            {
                Name = request.Name,
            };

            var teacherCalendars = new TeacherCalendar { TeacherId = teacher.Id, CalendarId = calendar.Id };

            calendar.AddTeacher(teacherCalendars);
            _dbContext.Calendars.Add(calendar);
            return Task.FromResult(_dbContext.SaveChanges());
        }
    }
}
