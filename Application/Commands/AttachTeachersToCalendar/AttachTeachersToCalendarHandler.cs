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

namespace Application.CommandUseCases.AttachTeachersToCalendar
{
    internal class AttachTeachersToCalendarHandler : BaseContext, IRequestHandler<AttachTeachersToCalendarCommand, bool>
    {
        public AttachTeachersToCalendarHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Task<bool> Handle(AttachTeachersToCalendarCommand request, CancellationToken cancellationToken)
        {
            Calendar calendar = _dbContext.Calendars.FirstOrDefault(c => c.Id == request.CalendarId);
            var teacherCalendars = request.Teachers.Select(tc => new TeacherCalendar { TeacherId = tc.Id, CalendarId = calendar.Id });

            calendar.AddTeachers(teacherCalendars);
            return Task.FromResult(_dbContext.SaveChanges());
        }
    }
}
