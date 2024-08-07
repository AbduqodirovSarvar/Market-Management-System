﻿using Application.UseCases.AddressToDoList.Commands;
using Application.UseCases.AddressToDoList.Queries;
using Application.UseCases.CountryToDoList.Commands;
using Application.UseCases.CountryToDoList.Queries;
using Application.UseCases.DistrictToDoList.Commands;
using Application.UseCases.DistrictToDoList.Queries;
using Application.UseCases.RegionToDoList.Commands;
using Application.UseCases.RegionToDoList.Queries;
using Application.UseCases.StreetToDoList.Commands;
using Application.UseCases.StreetToDoList.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(policy: "AdminActions")]
    public class AddressController(
        IMediator mediator
        ) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        // Country

        [HttpGet("country")]
        public async Task<IActionResult> GetCountry([FromQuery] GetCountryQuery query)
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

        [HttpGet("country/all")]
        public async Task<IActionResult> GetAllCountry([FromQuery] GetAllCountryQuery query)
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

        [HttpPost("country")]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryCommand command)
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

        [HttpPut("country")]
        public async Task<IActionResult> UpdateCountry([FromBody] UpdateCountryCommand command)
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

        [HttpDelete("country")]
        public async Task<IActionResult> DeleteCountry(DeleteCountryCommand command)
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


        // Region

        [HttpGet("region")]
        public async Task<IActionResult> GetRegion([FromQuery] GetRegionQuery query)
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

        [HttpGet("region/all")]
        public async Task<IActionResult> GetAllRegion([FromQuery] GetAllRegionQuery query)
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

        [HttpPost("region")]
        public async Task<IActionResult> CreateRegion([FromBody] CreateRegionCommand command)
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

        [HttpPut("region")]
        public async Task<IActionResult> UpdateCountry([FromBody] UpdateRegionCommand command)
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

        [HttpDelete("region")]
        public async Task<IActionResult> DeleteCountry(DeleteRegionCommand command)
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

        // District

        [HttpGet("district")]
        public async Task<IActionResult> GetDistrict([FromQuery] GetDistrictQuery query)
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

        [HttpGet("district/all")]
        public async Task<IActionResult> GetAllDistrict([FromQuery] GetAllDistrictQuery query)
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

        [HttpPost("district")]
        public async Task<IActionResult> CreateDistrict([FromBody] CreateDistrictCommand command)
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

        [HttpPut("district")]
        public async Task<IActionResult> UpdateDistrict([FromBody] UpdateDistrictCommand command)
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

        [HttpDelete("district")]
        public async Task<IActionResult> DeleteDistrict(DeleteDistrictCommand command)
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

        // Street

        [HttpGet("street")]
        public async Task<IActionResult> GetStreet([FromQuery] GetStreetQuery query)
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

        [HttpGet("street/all")]
        public async Task<IActionResult> GetAllStreet([FromQuery] GetAllStreetQuery query)
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

        [HttpPost("street")]
        public async Task<IActionResult> CreateStreet([FromBody] CreateStreetCommand command)
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

        [HttpPut("street")]
        public async Task<IActionResult> UpdateStreet([FromBody] UpdateStreetCommand command)
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

        [HttpDelete("street")]
        public async Task<IActionResult> DeleteStreet(DeleteStreetCommand command)
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

        // Address

        [HttpGet]
        public async Task<IActionResult> GetAddress([FromQuery] GetAddressQuery query)
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
        public async Task<IActionResult> GetAllAddress([FromQuery] GetAllAddressQuery query)
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
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommand command)
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
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressCommand command)
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
        public async Task<IActionResult> DeleteAddress(DeleteAddressCommand command)
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
