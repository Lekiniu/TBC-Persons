using Persons.Domain.AggregateModels.CityAggregate;
using Persons.Domain.AggregateModels.CityAggregate.Interfaces;
using Persons.Infrastructure.Persistance.Context;

namespace Persons.Infrastructure.Repositories
{
    public class CityRepository : GenericRepository<City, PersonDbContext>, ICityRepository
    {
        public CityRepository(PersonDbContext context) : base(context)
        {
        }
    }
}
