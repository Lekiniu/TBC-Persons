using Persons.Domain.Enums;

namespace Persons.Application.Features.Persons.Commands.AddRelatedPerson
{
    public class AddRelatedPersonModel
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public RelationTypes RelationType { get; set; }
    }
}
