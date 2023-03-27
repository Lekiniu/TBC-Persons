using Persons.Application.Common.Mappings;
using Persons.Domain.AggregateModels.PersonAggregate;

namespace Persons.Application.Common.Models
{
    public class CityModel : MapFrom<City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
