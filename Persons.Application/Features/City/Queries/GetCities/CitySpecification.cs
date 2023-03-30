using Persons.Application.Common.Specifications;
using System.Linq.Expressions;

namespace Persons.Application.Features.City.Queries.GetCities
{
    public class CitySpecification : Specification<Domain.AggregateModels.CityAggregate.City>
    {
        private Expression<Func<Domain.AggregateModels.CityAggregate.City, bool>> BaseExpression { get; set; } = u => u.IsActive;

        private readonly GetCityQuery _filter;

        public CitySpecification(GetCityQuery filter)
        {
            _filter = filter;
        }

        public override Expression<Func<Domain.AggregateModels.CityAggregate.City, bool>> ToExpression()
        {
            var result = BaseExpression;

            if (!string.IsNullOrWhiteSpace(_filter.Name))
            {
                result = result.And(x => x.Name.Contains(_filter.Name));
            }

            return result;
        }
    }
}
