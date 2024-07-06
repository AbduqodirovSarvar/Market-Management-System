using Application.UseCases.OrganizationToDoList.Commands;
using Application.UseCases.OrganizationToDoList.Queries;
using Application.UseCases.RoleToDoList.Commands;
using Application.UseCases.RoleToDoList.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(policy: "AdminActions")]
    public class OrganizationController(
        IMediator mediator
        ) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetOrganization([FromQuery] GetAllOrganizationQuery query)
        {
            try
            {
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrganization([FromQuery] GetAllOrganizationQuery query)
        {
            try
            {
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(policy: "SuperAdminActions")]
        [HttpPost]
        public async Task<IActionResult> CreateOrganization([FromBody] CreateOrganizationCommand command)
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

        [HttpPut]
        public async Task<IActionResult> UpdateOrganization([FromBody] UpdateOrganizationCommand command)
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

        [Authorize(policy: "SuperAdminActions")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrganization(DeleteOrganizationCommand command)
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
    }
}
