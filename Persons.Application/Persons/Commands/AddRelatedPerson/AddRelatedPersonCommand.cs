using MediatR;
using Persons.Application.Common.Mappings;
using Persons.Application.Persons.Commands.CreatePerson;
using Persons.Domain.Enums;

namespace Persons.Application.Persons.Commands.AddRelatedPerson
{
    public class AddRelatedPersonCommand : MapFrom<AddRelatedPersonModel>, IRequest<int>
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public RelationTypes RelationType { get; set; }
    }
}
