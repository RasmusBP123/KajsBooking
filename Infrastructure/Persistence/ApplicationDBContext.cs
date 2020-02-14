using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Joint;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext,  IApplicationDBContext
    {

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingType> BookingTypes { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeacherCalendar> TeacherCalendar { get; set; }
        public DbSet<StudentTeam> StudentTeam { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public new bool SaveChanges()
        {
            return base.SaveChanges() > 0;
        }
    }
}
