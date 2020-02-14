using Domain.Entities.Joint;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public List<StudentTeam> Students { get; set; } = new List<StudentTeam>();
        public Calendar Calendar { get; set; }

        public void AttachStudents(IEnumerable<StudentTeam> students)
        {
            Students.AddRange(students);
        }
    }
}
