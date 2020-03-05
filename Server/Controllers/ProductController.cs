using Application;
using Application.Commands.CreateProduct;
using Infrastructure.Mediator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProduct(CancellationToken token)
        {
            var command = new CreateProductCommand(0, 1, "How you doin'?");
            await _mediator.SendAsync(command, token);
            return Ok();
        }
    }
}
