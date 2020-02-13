using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Calendar
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeacherCalendar> Teachers { get; set; } = new List<TeacherCalendar>();
        public List<Timeslot> Timeslots { get; set; } = new List<Timeslot>();

        public void AddTeacher(TeacherCalendar teacher)
        {
            Teachers.Add(teacher);
        }
    }
}
