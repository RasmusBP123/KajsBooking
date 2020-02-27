using Ports.ViewModels;
using System;

namespace Ports.ViewModels
{
    public class BookingViewMdel
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public StudentViewModel Student { get; set; }
        public BookingTypeViewModel Type { get; set; }
    }
}