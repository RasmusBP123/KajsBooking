using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Teacher : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeacherCalendar> Calendars { get; set; }
        public ICollection<Timeslot> Timeslots { get; set; }

        public void CreateTimeSlot(Timeslot timeslot)
        {
            this.Timeslots.Add(timeslot);
        }
    }
}
