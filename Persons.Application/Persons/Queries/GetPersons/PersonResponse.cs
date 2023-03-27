using Persons.Application.Common.Mappings;
using Persons.Application.Common.Models;
using Persons.Domain.AggregateModels.PersonAggregate;
using Persons.Domain.Enums;

namespace Persons.Application.Persons.Queries.GetPersons
{
    public class PersonResponse : MapFrom<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderTypes Gender { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
