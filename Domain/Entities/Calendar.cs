using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Calendar : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeacherCalendar> Teachers { get; set; }
        public ICollection<Timeslot> Timeslots { get; set; }
    }
}
