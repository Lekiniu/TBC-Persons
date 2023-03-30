using Persons.Application.Common.Mappings;

namespace Persons.Application.Features.City.Queries.GetCities
{
    public class CityModel : MapFrom<Domain.AggregateModels.CityAggregate.City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
