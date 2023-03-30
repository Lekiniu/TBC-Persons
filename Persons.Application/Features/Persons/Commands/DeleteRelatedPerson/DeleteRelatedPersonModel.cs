using Persons.Domain.Enums;

namespace Persons.Application.Features.Persons.Commands.DeleteRelatedPerson
{
    public class DeleteRelatedPersonModel
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
    }
}
