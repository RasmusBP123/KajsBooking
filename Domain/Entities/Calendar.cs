using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Calendar
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<TeacherCalendar> Teachers { get; set; } = new List<TeacherCalendar>();
        public virtual List<Timeslot> Timeslots { get; set; } = new List<Timeslot>();
        public virtual List<Team> Teams { get; set; }

        public void AddTeacher(TeacherCalendar teacher)
        {
            Teachers.Add(teacher);
        }

        public void AddTeachers(IEnumerable<TeacherCalendar> teachers)
        {
            Teachers.AddRange(teachers);
        }
    }
}
