using Application.Common.Base;
using Application.Common.Interfaces;
using Application.Dtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.GetAllStudents
{
    public class GetAllStudentsHandler : BaseContext, IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDTO>>
    {
        public GetAllStudentsHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<StudentDTO>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _dbContext.Students.ToListAsync();
            var studentsDto = _mapper.Map<IEnumerable<StudentDTO>>(students);
            return studentsDto;
        }
    }
}
