using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Timeslot
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public virtual List<Booking> Bookings { get; set; } = new List<Booking>();
        public virtual Calendar Calendar { get; set; }
        public virtual Teacher Teacher { get; set; }

        public void CreateBooking(Booking booking) => Bookings.Add(booking);

        public bool IsBookingPossible(Booking newBooking)
        {
            var result = Bookings.All(existingBooking => newBooking.From >= existingBooking.To || newBooking.To <= existingBooking.From);
            return result;
        }

        public bool IsTimeslotsOverlapping(List<Timeslot> timeslotsWhereTeacherIsPresent, Timeslot newTimeslot)
        {
            var result = timeslotsWhereTeacherIsPresent.All(existingTimeslots => newTimeslot.From >= existingTimeslots.To || newTimeslot.To <= existingTimeslots.From);
            return result;
        }
    }
}
