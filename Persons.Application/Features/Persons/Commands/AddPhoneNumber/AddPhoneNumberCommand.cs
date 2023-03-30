using MediatR;
using Persons.Application.Common.Mappings;
using Persons.Domain.Enums;

namespace TBC.Application.Features.Person.Commands.AddPersonContact
{
    public class AddPhoneNumberCommand : MapFrom<AddPhoneNumberModel>, IRequest<Unit>
    {
        public int PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneNumberTypes PhoneNumberType { get; set; }
    }
}
