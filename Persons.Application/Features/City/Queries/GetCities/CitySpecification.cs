using Persons.Application.Common.Specifications;
using System.Linq.Expressions;
using Cities = Persons.Domain.AggregateModels.CityAggregate.City;

namespace Persons.Application.Features.City.Queries.GetCities
{
    public class CitySpecification 
    {
        private Expression<Func<Cities, bool>> BaseExpression { get; set; } = u => u.IsActive;

        public CitySpecification(string? name)
        {
            Name = name;
        }

        public string? Name { get; set; }

        public List<Expression<Func<Cities, bool>>> ToExpression()
        {
            List<Expression<Func<Cities, bool>>> expressions = new List<Expression<Func<Cities, bool>>>
                {
                    BaseExpression
                };

            if (!string.IsNullOrWhiteSpace(Name))
            {
                expressions.Add(x => x.Name.ToLower().Contains(Name.ToLower()));
            }

            return expressions;
        }
    }
}
