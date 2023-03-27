using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persons.Application.Persons.Commands.AddRelatedPerson;
using Persons.Application.Persons.Commands.CreatePerson;
using Persons.Application.Persons.Commands.UpdatePerson;
using Persons.Application.Persons.Queries.GetPersonDetails;
using Persons.Application.Persons.Queries.GetPersons;

namespace Persons.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {

        private readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public PersonsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get person List
        /// </summary>
        [HttpGet(Name = nameof(GetPersons))]
        [ProducesResponseType(typeof(PersonDetailsModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPersons([FromRoute] GetPersonsModel  request)
        {
            var query =  _mapper.Map<GetPersonsQuery>(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Get person details
        /// </summary>
        [HttpGet("{id}", Name = nameof(GetPersoDetails))]
        [ProducesResponseType(typeof(PersonDetailsModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPersoDetails([FromRoute] int id)
        {
            var query = new GetPersonDetailsQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        /// <summary>
        /// Creates Person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(template: nameof(CreatePerson), Name = nameof(CreatePerson))]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonModel request)
        {
            var command = _mapper.Map<CreatePersonCommand>(request);
            var result = await _mediator.Send(command);

            return Created(string.Empty, result);
        }

        /// <summary>
        ///Add File
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(template: nameof(AddFile), Name = nameof(AddFile))]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddFile([FromBody] AddFilePersonModel model)
        {
            var command = _mapper.Map<AddFileCommand>(model);
            var result = await _mediator.Send(command);
            return Created(string.Empty, result);
        }

        /// <summary>
        /// Update Person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut(template: nameof(UpdatePerson), Name = nameof(UpdatePerson))]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonModel request)
        {
            var command = _mapper.Map<UpdatePersonCommand>(request);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Delete Person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = nameof(DeletePerson))]
        [ProducesResponseType(typeof(int), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {
            var command = new DeletePersonCommand { Id = id };
             await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        ///Add Related Person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(template: nameof(AddRelatedPerson), Name = nameof(AddRelatedPerson))]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddRelatedPerson([FromBody] AddRelatedPersonModel model)
        {
            var command = _mapper.Map<AddRelatedPersonCommand>(model);
            var result = await _mediator.Send(command);
            return Created(string.Empty, result);
        }

        /// <summary>
        /// Delete RelatedPerson
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete(template: nameof(DeleteRelatedPerson), Name = nameof(DeleteRelatedPerson))]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteRelatedPerson([FromQuery] DeleteRelatedPersonModel model)
        {
            var command = _mapper.Map<DeleteRelatedPersonCommand>(model);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}