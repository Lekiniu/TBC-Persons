using Persons.Application.Common.Mappings;
using Persons.Domain.AggregateModels.PersonAggregate;
using Persons.Domain.Enums;

namespace Persons.Application.Common.Models
{
    public class PhoneNumberDetails : MapFrom<PhoneNumber>
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public PhoneNumberTypes PhoneNumberType { get; set; }
    }
}
