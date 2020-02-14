using Application.Common.Base;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CreateTeam
{
    public class CreateTeamHandler : BaseContext, IRequestHandler<CreateTeamCommand, bool>
    {
        public CreateTeamHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Task<bool> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {

            var teacher = _dbContext.Teachers.FirstOrDefault(t => t.Id == request.TeacherId);

            var team = new Team
            {
                Name = request.Name,
                Teacher = teacher
            };

            _dbContext.Teams.Add(team);
            return Task.FromResult(_dbContext.SaveChanges());
        }
    }
}
