using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Todo : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
