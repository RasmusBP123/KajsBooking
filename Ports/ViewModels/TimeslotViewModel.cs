using System;
using System.Collections.Generic;

namespace Ports.ViewModels
{
    public class TimeslotViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public List<BookingViewMdel> Bookings { get; set; }
        public TeacherViewModel Teacher { get; set; }
    }
}