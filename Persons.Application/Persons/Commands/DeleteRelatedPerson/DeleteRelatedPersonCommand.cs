using MediatR;
using Persons.Application.Common.Mappings;
using Persons.Domain.Enums;

namespace Persons.Application.Persons.Commands.AddRelatedPerson
{
    public class DeleteRelatedPersonCommand : MapFrom<DeleteRelatedPersonModel>,  IRequest<int>
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
    }
}
