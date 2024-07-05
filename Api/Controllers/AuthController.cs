using Application.UseCases.AuthToDoList.Commands;
using Application.UseCases.InComeToDoList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
        IMediator mediator
        ) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] LoginCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] RegisterCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> getQr()
        {
            try
            {
                return Ok(await _mediator.Send(new Test()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
