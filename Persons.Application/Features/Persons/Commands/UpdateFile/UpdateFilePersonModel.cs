using Microsoft.AspNetCore.Http;
using Persons.Domain.Enums;

namespace Persons.Application.Features.Persons.Commands.UpdateFile
{
    public class UpdateFilePersonModel
    {
        public int PersonId { get; set; }
        public IFormFile File { get; set; }
    }
}
