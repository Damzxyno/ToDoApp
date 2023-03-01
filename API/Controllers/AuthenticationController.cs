using Core.Handlers.Commands;
using Core.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IMediator _mediator;
        public AuthenticationController(ILogger<AuthenticationController> logger, IMediator mediator)
        {

            _logger = logger;
            _mediator = mediator;

        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseEntity<LoginCommand>), (int) HttpStatusCode.OK)]
        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromBody]LoginCommand loginCommand)
        {
            var response = await _mediator.Send(loginCommand);
            return Ok(response);
        }
    }
}
