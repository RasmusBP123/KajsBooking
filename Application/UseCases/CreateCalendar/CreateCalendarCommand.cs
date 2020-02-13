using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.CreateCalendar
{
    public class CreateCalendarCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public Guid? TeacherId { get; set; }

        public CreateCalendarCommand(string name, Guid? teacherId)
        {
            Name = name;
            TeacherId = teacherId;
        }
    }
}
