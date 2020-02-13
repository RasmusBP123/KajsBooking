using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class BookingType
    {
        public Guid Id { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
