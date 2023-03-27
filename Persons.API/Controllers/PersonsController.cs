using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persons.Application.Persons.Queries.GetPersonDetails;

namespace Persons.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PersonsController(IMediator mediator)
        {
            _mediator = mediator;
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
    }
}