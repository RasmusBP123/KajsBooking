using Application.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Text;

namespace Application.QueryUseCases.GetCalendarForTeam
{
    public class GetCalendarForTeamQuery : IRequest<CalendarDTO>
    {
        public Guid CalendarId { get; }
        public GetCalendarForTeamQuery(Guid calendarId)
        {
            CalendarId = calendarId;
        }
    }
}
