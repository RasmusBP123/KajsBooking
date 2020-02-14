using System;

namespace Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public virtual BookingType Type { get; set; }
        public virtual Student Student { get; set; }
    }
}
