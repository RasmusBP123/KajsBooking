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
        public virtual Teacher Teacher { get; set; }
        public virtual List<StudentTeam> Students { get; set; } = new List<StudentTeam>();
        public virtual Calendar Calendar { get; set; }

        public void AttachStudents(IEnumerable<StudentTeam> students)
        {
            Students.AddRange(students);
        }
    }
}
