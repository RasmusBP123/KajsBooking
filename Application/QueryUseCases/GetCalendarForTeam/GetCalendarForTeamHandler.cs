using Application.Common.Base;
using Application.Common.Interfaces;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QueryUseCases.GetCalendarForTeam
{
    public class GetCalendarForTeamHandler : BaseContext, IRequestHandler<GetCalendarForTeamQuery, CalendarDTO>
    {
        public GetCalendarForTeamHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Task<CalendarDTO> Handle(GetCalendarForTeamQuery request, CancellationToken cancellationToken)
        {
            var calendar = _dbContext.Calendars.Include(c => c.Timeslots)
                                   .ThenInclude(t => t.Bookings)
                                   .ThenInclude(b => b.Type)
                                   .Include(c => c.Timeslots)
                                   .ThenInclude(t => t.Teacher)
                                   .Include(c => c.Teachers)
                                   .ThenInclude(t => t.Teacher)
                                   .Include(c => c.Teams)
                                   .FirstOrDefault(c => c.Id == request.CalendarId);

            calendar.Teachers.Select(t => new Teacher { Id = t.TeacherId, Name = t.Teacher.Name });
            var result = _mapper.Map<CalendarDTO>(calendar);

            return Task.FromResult(result);
        }
    }
}
