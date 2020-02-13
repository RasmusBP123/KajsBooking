using Domain.Entities.Joint;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public List<StudentTeam> Students { get; set; }
    }
}
