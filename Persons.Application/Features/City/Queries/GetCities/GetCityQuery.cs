using MediatR;
using Persons.Application.Common.Mappings;
using Persons.Application.Common.PagedList;

namespace Persons.Application.Features.City.Queries.GetCities
{
    public class GetCityQuery : MapFrom<GetCityModel>, IRequest<PagedList<CityModel>>
    {
        public string? Name { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
