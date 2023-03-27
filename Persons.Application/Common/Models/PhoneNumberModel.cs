using Persons.Application.Common.Mappings;
using Persons.Domain.AggregateModels.PersonAggregate;

namespace Persons.Application.Common.Models
{
    public class PhoneNumberModel : MapFrom<PhoneNumber>
    {
        public int Id { get; set; }
        public string Number { get; set; }
    }
}
