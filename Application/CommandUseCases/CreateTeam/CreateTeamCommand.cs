using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.CreateTeam
{
    public class CreateTeamCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public Guid TeacherId { get; set; }

        public CreateTeamCommand(string name, Guid teacherId)
        {
            Name = name;
            TeacherId = teacherId;
        }
    }
}
