using MediatR;
using Persons.Domain.Enums;

namespace Persons.Application.Persons.Commands.AddRelatedPerson
{
    public class DeleteRelatedPersonCommand :  IRequest<int>
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
    }
}
