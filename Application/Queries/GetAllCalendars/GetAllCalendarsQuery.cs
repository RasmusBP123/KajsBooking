using Application.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Queries.GetAllCalendars
{
    public class GetAllCalendarsQuery : IRequest<List<CalendarDTO>>
    {
    }
}
