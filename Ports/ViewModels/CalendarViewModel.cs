using System;
using System.Collections.Generic;
using System.Text;

namespace Ports.ViewModels
{
    public class CalendarViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TeacherViewModel> Teachers { get; set; }
        public List<TimeslotViewModel> Timeslots { get; set; }
        public List<TeamViewModel> Teams { get; set; }
    }
}
