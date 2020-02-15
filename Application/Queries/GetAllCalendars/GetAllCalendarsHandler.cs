using Application.Common.Base;
using Application.Common.Interfaces;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.GetAllCalendars
{
    public class GetAllCalendarsHandler : BaseContext, IRequestHandler<GetAllCalendarsQuery, List<CalendarDTO>>
    {
        public GetAllCalendarsHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Task<List<CalendarDTO>> Handle(GetAllCalendarsQuery request, CancellationToken cancellationToken)
        {
            var calendarEntities = _dbContext.Calendars.ToList();
            var calendars = _mapper.Map<List<CalendarDTO>>(calendarEntities);

            return Task.FromResult(calendars);
        }
    }
}
