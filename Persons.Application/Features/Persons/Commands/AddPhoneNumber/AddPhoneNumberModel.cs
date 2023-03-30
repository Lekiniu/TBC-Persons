using Persons.Domain.Enums;

namespace TBC.Application.Features.Person.Commands.AddPersonContact
{
    public class AddPhoneNumberModel
    {
        public int PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneNumberTypes PhoneNumberType { get; set; }
    }
}
