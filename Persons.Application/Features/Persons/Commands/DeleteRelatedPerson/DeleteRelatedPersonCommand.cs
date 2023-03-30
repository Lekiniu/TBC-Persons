using MediatR;
using Persons.Application.Common.Mappings;
using Persons.Domain.Enums;

namespace Persons.Application.Features.Persons.Commands.DeleteRelatedPerson
{
    public class DeleteRelatedPersonCommand : MapFrom<DeleteRelatedPersonModel>,  IRequest<Unit>
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
    }
}
