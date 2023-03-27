using Microsoft.AspNetCore.Http;
using Persons.Domain.Enums;

namespace Persons.Application.Persons.Commands.CreatePerson
{
    public class AddFilePersonModel
    {
        public int PersonId { get; set; }
        public IFormFile File { get; set; }
    }
}
