﻿using Domain.Common;
using Domain.Entities.Joint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<StudentTeam> Teams { get; set; }
        public virtual List<Booking> Bookings { get; set; }


        public bool IsBookingLimitReached()
        {
            var result = Bookings.Where(b => b.To > DateTime.Now).Count() >= 2;
            return result;
        }
    }
}
