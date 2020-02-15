using Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class OverlappingTests
    {
        [Fact]
        public void IsTimeslotsOverlapping()
        { 
            var listOftimeslots = new List<Timeslot>
            {
                new Timeslot()
                {
                    From = new DateTime(2020, 02, 12, 15, 00, 00),
                    To = new DateTime(2020, 02, 12, 17, 00, 00)
                },
                new Timeslot()
                {
                    From = new DateTime(2020, 02, 12, 14, 00, 00),
                    To = new DateTime(2020, 02, 12, 16, 00, 00)
                }
            };

            var timeslotWhichIsOverlapping = new Timeslot
            {
                From = new DateTime(2020, 02, 12, 14, 00, 00),
                To = new DateTime(2020, 02, 12, 16, 00, 00)
            };

            var timeslotWhichIsNOTOverlapping = new Timeslot
            {
                From = new DateTime(2020, 02, 12, 13, 00, 00),
                To = new DateTime(2020, 02, 12, 14, 00, 00)
            };

            var isPossibleToCreateTimeslot = timeslotWhichIsOverlapping.IsTimeslotsOverlapping(listOftimeslots, timeslotWhichIsNOTOverlapping);
            var isNOTpossibleToCreateTimeslot = timeslotWhichIsOverlapping.IsTimeslotsOverlapping(listOftimeslots, timeslotWhichIsOverlapping);

            Assert.True(isPossibleToCreateTimeslot);
            Assert.False(isNOTpossibleToCreateTimeslot);
        }

        [Fact]
        public void IsBookingOverlapping()
        {
            var timeslot = new Timeslot
            {
                Bookings = new List<Booking>
                {
                    new Booking
                    {
                         From = new DateTime(2020, 02, 12, 13, 00, 00),
                         To = new DateTime(2020, 02, 12, 14, 00, 00)
                    },
                    new Booking
                    {
                         From = new DateTime(2020, 02, 12, 14, 00, 00),
                         To = new DateTime(2020, 02, 12, 16, 00, 00),
                    }
                }
            };

            var bookingWhichISPossible = new Booking
            {
                From = new DateTime(2020, 02, 12, 16, 00, 00),
                To = new DateTime(2020, 02, 12, 18, 00, 00)
            };

            var bookingWhichNOTPossible = new Booking
            {
                From = new DateTime(2020, 02, 12, 13, 00, 00),
                To = new DateTime(2020, 02, 12, 15, 00, 00)
            };

            var bookingIsPossible = timeslot.IsBookingPossible(bookingWhichISPossible);
            var bookingNOTPossible = timeslot.IsBookingPossible(bookingWhichNOTPossible);

            Assert.True(bookingIsPossible);
            Assert.False(bookingNOTPossible);
        }
    }
}
