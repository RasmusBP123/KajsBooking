using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Ports.ViewModels;
using System.Linq;

namespace Ports.Mappings
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            //CreateMap<CalendarDTO, CalendarViewModel>().ForMember(dto => dto.Teachers, opt => opt.MapFrom(x => x.Teachers.Select(t => t.Teacher).ToList()));
            CreateMap<StudentDTO, StudentViewModel>();
        }
    }
}
