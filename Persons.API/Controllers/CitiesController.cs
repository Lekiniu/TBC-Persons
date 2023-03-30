using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persons.Application.Common.PagedList;
using Persons.Application.Features.City.Commands.CreateCity;
using Persons.Application.Features.City.Commands.DeleteCity;
using Persons.Application.Features.City.Commands.UpdateCity;
using Persons.Application.Features.City.Queries.GetCities;
using Persons.Application.Features.Persons.Commands.CreatePerson;

namespace TBC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        public readonly IMapper _mapper;
        public IMediator _mediator;

        /// <summary>
        /// Cities Controller
        /// </summary>
        public CitiesController(
            IMapper mapper, 
            IMediator mediator
            )
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// CreateCity
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(template: nameof(CreateCity), Name = nameof(CreateCity))]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityModel request)
        {
            var command = _mapper.Map<CreateCityCommand>(request);
            var result = await _mediator.Send(command);

            return Created(string.Empty, result);
        }

        /// <summary>
        /// Update City
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}", Name = nameof(UpdateCity))]
        public async Task<IActionResult> UpdateCity([FromRoute] int id, [FromBody] UpdateCityModel request)
        {
            var command = _mapper.Map<UpdateCityCommand>(request);
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete City
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}", Name = nameof(DeleteCity))]
        public async Task<IActionResult> DeleteCity([FromRoute] int id)
        {
            var command = new DeleteCityCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
        /// <summary>
        /// Get Cities List
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>  
        [HttpGet(template: nameof(GetCities), Name = nameof(GetCities))]
        [ProducesResponseType(typeof(PagedList<CityModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCities([FromQuery] GetCityModel request)
        {
            var query = _mapper.Map<GetCityQuery>(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
