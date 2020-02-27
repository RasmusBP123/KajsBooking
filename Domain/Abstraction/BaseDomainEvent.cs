using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstraction
{
    public class BaseDomainEvent
    {
        public int Version { get; set; }
    }
}
