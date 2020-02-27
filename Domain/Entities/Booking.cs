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


        public static Booking Create(DateTime from, DateTime to, BookingType type)
        {
            return new Booking { From = from, To = to, Type = type};
        }
    }
}
