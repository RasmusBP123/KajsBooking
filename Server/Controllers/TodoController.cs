using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Item.Queries.GetTodos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class TodoController : ApiController
    {
        public TodoController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await _mediator.Send(new GetAllTodosQuery());
            return Ok(todos);
        }
    }
}