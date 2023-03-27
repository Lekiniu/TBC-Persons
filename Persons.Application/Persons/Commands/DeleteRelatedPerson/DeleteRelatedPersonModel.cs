using Persons.Domain.Enums;

namespace Persons.Application.Persons.Commands.AddRelatedPerson
{
    public class DeleteRelatedPersonModel
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public RelationTypes RelationType { get; set; }
    }
}
