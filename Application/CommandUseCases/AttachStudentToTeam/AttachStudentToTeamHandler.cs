using Application.Common.Base;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Joint;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.AttachStudentToTeam
{
    public class AttachStudentToTeamHandler : BaseContext, IRequestHandler<AttachStudentToTeamCommand, bool>
    {
        public AttachStudentToTeamHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Task<bool> Handle(AttachStudentToTeamCommand request, CancellationToken cancellationToken)
        {
            var team = _dbContext.Teams.FirstOrDefault(t => t.Id == request.TeamId);
            var studentTeams = request.Students.Select(st => new StudentTeam { StudentId = st.Id, TeamId = team.Id});

            team.AttachStudents(studentTeams);

            return Task.FromResult(_dbContext.SaveChanges());
        }
    }
}
