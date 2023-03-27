using Persons.Domain.AggregateModels.PersonAggregate;
using Persons.Domain.AggregateModels.PersonAggregate.Interfaces;
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
