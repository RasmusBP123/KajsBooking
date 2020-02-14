using Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class StudentBookingTests
    {
        [Fact]
        public void StudentHasExceedMaximumBookingLimit()
        {
            var studentBjarne = new Student
            {
                Bookings = new List<Booking>
                {
                    new Booking
                    {
                         From = new DateTime(2500, 02, 12, 13, 00, 00),
                         To = new DateTime(2500, 02, 12, 14, 00, 00)
                    },
                    new Booking
                    {
                         From = new DateTime(2500, 02, 12, 14, 00, 00),
                         To = new DateTime(2500, 02, 12, 16, 00, 00),
                    },
                    new Booking
                    {
                         From = new DateTime(2500, 02, 12, 17, 00, 00),
                         To = new DateTime(2500, 02, 12, 20, 00, 00),
                    }
                }
            };

            var studentRasmus = new Student
            {
                Bookings = new List<Booking>
                {
                    new Booking
                    {
                         From = new DateTime(2500, 02, 12, 13, 00, 00),
                         To = new DateTime(2500, 02, 12, 14, 00, 00)
                    },
                }
            };

            var studentBookingISreached = studentBjarne.IsBookingLimitReached();
            var studentBookingNOTreached = studentRasmus.IsBookingLimitReached();

            Assert.True(studentBookingISreached);
            Assert.False(studentBookingNOTreached);
        }
    }
}
