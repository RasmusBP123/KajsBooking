using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Timeslot
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();

        public void CreateBooking(Booking booking)
        {
            this.Bookings.Add(booking);
        }
    }
}
