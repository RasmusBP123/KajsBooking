using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using System.Linq;

namespace Application.Common.Mappings
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<BookingType, BookingTypeDTO>();
            CreateMap<Booking, BookingDTO>();
            CreateMap<Calendar, CalendarDTO>().ForMember(dto => dto.Teachers, opt => opt.MapFrom(x => x.Teachers.Select(t => t.Teacher).ToList()));
            CreateMap<Student, StudentDTO>();
            CreateMap<Teacher, TeacherDTO>();
            CreateMap<Team, TeamDTO>();
            CreateMap<Timeslot, TimeslotDTO>();
        }
    }
}
