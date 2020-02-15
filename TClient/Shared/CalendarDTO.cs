using System;
using System.Collections.Generic;

namespace TClient.Shared
{
    public class CalendarDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TeacherDTO> Teachers { get; set; }
        public List<TimeslotDTO> Timeslots { get; set; }
        public List<TeamDTO> Teams { get; set; }
    }
}
