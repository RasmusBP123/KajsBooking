using System;

namespace Domain.Entities
{
    public class BookingType
    {
        public Guid Id { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
