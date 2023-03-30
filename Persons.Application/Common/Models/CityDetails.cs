using Persons.Application.Common.Mappings;
using Persons.Domain.AggregateModels.CityAggregate;

namespace Persons.Application.Common.Models
{
    public class CityDetails : MapFrom<City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
