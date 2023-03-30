using MediatR;
using Microsoft.AspNetCore.Http;
using Persons.Application.Common.Mappings;
using Persons.Domain.Enums;

namespace Persons.Application.Features.Persons.Commands.AddFile
{
    public class AddFileCommand : MapFrom<AddFilePersonModel>, IRequest<int>
    {
        public int PersonId { get; set; }
        public IFormFile File { get; set; }
    }
}
