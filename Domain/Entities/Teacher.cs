﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Teacher
    {
        public Teacher()
        { }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeacherCalendar> Calendars { get; set; }
        public List<Timeslot> Timeslots { get; set; } = new List<Timeslot>();

        public Teacher(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void CreateTimeSlot(Timeslot timeslot)
        {
            this.Timeslots.Add(timeslot);
        }
    }
}
