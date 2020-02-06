using Domain.Common;
using Domain.Entities.Joint;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Student : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<StudentTeam> Teams { get; set; }
    }
}
