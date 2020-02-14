using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.AttachStudentToTeam;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class StudentController : ApiController
    {
        public StudentController(IMediator mediator) : base(mediator)
        {
        }


    }
}