using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Teacher
    {
        public Teacher()
        { }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<TeacherCalendar> Calendars { get; set; }
        public virtual List<Timeslot> Timeslots { get; set; } = new List<Timeslot>();
        public virtual ApplicationUser User { get; set; }

        public Teacher(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void CreateTimeSlot(Timeslot timeslot)
        {
            this.Timeslots.Add(timeslot);
        }

        public bool IsTimeslotOverlapping(List<TeacherCalendar> teacherCalendars)
        {
            var calendars = teacherCalendars.Select(tc => new Calendar { Id = tc.CalendarId, Timeslots = this.Timeslots});
            return true;
        }
    }
}
