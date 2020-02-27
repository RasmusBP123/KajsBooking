using Application.Queries.GetAllStudents;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ports.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IMapper _mapper;

        public StudentController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllStudents()
        {
            var studentsDTO = await _mediator.Send(new GetAllStudentsQuery());
            var studentsViewModel = _mapper.Map<IEnumerable<StudentViewModel>>(studentsDTO);
            return Ok(studentsViewModel);
        }

    }
}