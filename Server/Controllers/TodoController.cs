using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Item.Queries.GetTodos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ApiController
    {

        [HttpGet()]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await _mediator.Send(new GetAllTodosQuery());
            return Ok(todos);
        }
    }
}