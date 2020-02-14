using System;
using System.Collections.Generic;

namespace Application.Dtos
{
    public class TimeslotDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public List<BookingDTO> Bookings { get; set; }
        public TeacherDTO Teacher { get; set; }
    }
}