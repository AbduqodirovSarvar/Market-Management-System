﻿using Application.UseCases.AddressToDoList.Commands;
using Application.UseCases.AddressToDoList.Queries;
using Application.UseCases.InComeToDoList.Commands;
using Application.UseCases.InComeToDoList.Queries;
using Application.UseCases.MeasureOfTypetoDoList.Commands;
using Application.UseCases.MeasureOfTypetoDoList.Queries;
using Application.UseCases.OutComeToDoList.Commands;
using Application.UseCases.OutComeToDoList.Queries;
using Application.UseCases.ProductPriceToDoList.Commands;
using Application.UseCases.ProductPriceToDoList.Queries;
using Application.UseCases.ProductToDoList.Commands;
using Application.UseCases.ProductToDoList.Queries;
using Application.UseCases.ProductTypeToDoList.Commands;
using Application.UseCases.ProductTypeToDoList.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(policy: "AdminActions")]
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

        // InCome

        [HttpGet("in")]
        public async Task<IActionResult> GetInCome([FromQuery] GetInComeQuery query)
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

        [HttpGet("in/all")]
        public async Task<IActionResult> GetAllInCome([FromQuery] GetAllInComeQuery query)
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

        [HttpPost("in")]
        public async Task<IActionResult> CreateInCome([FromBody] CreateInComeCommand command)
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

        [HttpPut("in")]
        public async Task<IActionResult> UpdateInCome([FromBody] UpdateInComeCommand command)
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

        [HttpDelete("in")]
        public async Task<IActionResult> DeleteInCome(DeleteInComeCommand command)
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

        // OutCome

        [HttpGet("out")]
        public async Task<IActionResult> GetOutCome([FromQuery] GetOutComeQuery query)
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

        [HttpGet("out/all")]
        public async Task<IActionResult> GetAllOutCome([FromQuery] GetAllOutComeQuery query)
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

        [HttpPost("out")]
        public async Task<IActionResult> CreateOutCome([FromBody] CreateOutComeCommand command)
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

        [HttpPut("out")]
        public async Task<IActionResult> UpdateOutCome([FromBody] UpdateOutComeCommand command)
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

        [HttpDelete("out")]
        public async Task<IActionResult> DeleteOutCome(DeleteOutComeCommand command)
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

        // Price

        [HttpGet("price")]
        public async Task<IActionResult> GetPrice([FromQuery] GetProductPriceQuery query)
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

        [HttpGet("price/all")]
        public async Task<IActionResult> GetAllPrice([FromQuery] GetAllProductPriceQuery query)
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

        [HttpPost("price")]
        public async Task<IActionResult> CreatePrice([FromBody] CreateProductPriceCommand command)
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

        [HttpPut("price")]
        public async Task<IActionResult> UpdatePrice([FromBody] UpdateProductPriceCommand command)
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

        [HttpDelete("price")]
        public async Task<IActionResult> DeletePrice(DeleteProductPriceCommand command)
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
