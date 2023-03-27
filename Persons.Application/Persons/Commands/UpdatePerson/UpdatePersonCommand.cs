using MediatR;
using Persons.Application.Common.Models;
using Persons.Domain.Enums;

namespace Persons.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommand :  IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderTypes Gender { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public List<PhoneNumberModel> PhoneNumbers { get; set; }
    }
}
