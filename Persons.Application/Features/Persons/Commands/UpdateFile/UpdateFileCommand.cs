using MediatR;
using Microsoft.AspNetCore.Http;
using Persons.Application.Common.Mappings;
using Persons.Domain.Enums;

namespace Persons.Application.Features.Persons.Commands.UpdateFile
{
    public class UpdateFileCommand : MapFrom<UpdateFilePersonModel>, IRequest<int>
    {
        public int PersonId { get; set; }
        public IFormFile File { get; set; }
    }
}
