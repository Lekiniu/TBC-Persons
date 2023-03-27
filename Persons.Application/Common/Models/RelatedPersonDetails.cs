using Persons.Application.Common.Mappings;
using Persons.Domain.AggregateModels.PersonAggregate;
using Persons.Domain.Enums;

namespace Persons.Application.Common.Models
{
    public class RelatedPersonDetails : MapFrom<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderTypes Gender { get; set; }
        public string PersonalNumber { get; set; }
    }
}
