using System;

namespace Application.Dtos
{
    public class BookingDTO
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public StudentDTO Student { get; set; }
        public BookingTypeDTO Type { get; set; }
    }
}