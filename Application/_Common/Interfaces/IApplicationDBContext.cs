using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDBContext
    {
        DbSet<Todo> Todos { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingType> BookingTypes { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<Team> Teams { get; set; }
        bool SaveChanges();
    }
}
