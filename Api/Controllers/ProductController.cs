using Application.UseCases.AddressToDoList.Commands;
using Application.UseCases.AddressToDoList.Queries;
using Application.UseCases.MeasureOfTypetoDoList.Commands;
using Application.UseCases.MeasureOfTypetoDoList.Queries;
using Application.UseCases.ProductToDoList.Commands;
using Application.UseCases.ProductToDoList.Queries;
using Application.UseCases.ProductTypeToDoList.Commands;
using Application.UseCases.ProductTypeToDoList.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(
        IMediator mediator
        ) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        // Product

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetProductQuery query)
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
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQuery query)
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

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductCommand command)
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
        public async Task<IActionResult> Update([FromForm] UpdateProductCommand command)
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

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductCommand command)
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

        // Product Type

        [HttpGet("type")]
        public async Task<IActionResult> GetType([FromQuery] GetProductTypeQuery query)
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

        [HttpGet("type/all")]
        public async Task<IActionResult> GetAllType([FromQuery] GetAllProductTypeQuery query)
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

        [HttpPost("type")]
        public async Task<IActionResult> CreateType([FromBody] CreateProductTypeCommand command)
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

        [HttpPut("type")]
        public async Task<IActionResult> UpdateType([FromBody] UpdateProductTypeCommand command)
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

        [HttpDelete("type")]
        public async Task<IActionResult> DeleteType(DeleteProductTypeCommand command)
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

        // Measure of type

        [HttpGet("measure-of-type")]
        public async Task<IActionResult> GetMeasureOfType([FromQuery] GetMeasureOfTypeQuery query)
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

        [HttpGet("measure-of-type/all")]
        public async Task<IActionResult> GetAllMeasureOfType([FromQuery] GetAllMeasureOfTypeQuery query)
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

        [HttpPost("measure-of-type")]
        public async Task<IActionResult> CreateMeasureOfType([FromBody] CreateMesureOfTypeCommand command)
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

        [HttpPut("measure-of-type")]
        public async Task<IActionResult> UpdateMeasureOfType([FromBody] UpdateMeasureOfTypeCommand command)
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

        [HttpDelete("measure-of-type")]
        public async Task<IActionResult> DeleteMeasureOfType(DeleteMeasureOfTypeCommand command)
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
