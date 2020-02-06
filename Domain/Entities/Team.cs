using Domain.Common;
using Domain.Entities.Joint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Team : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<StudentTeam> Students { get; set; }
    }
}
