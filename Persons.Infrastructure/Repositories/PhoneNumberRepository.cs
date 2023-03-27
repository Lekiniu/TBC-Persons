using Persons.Domain.AggregateModels.PersonAggregate;
using Persons.Domain.AggregateModels.PersonAggregate.Interfaces;
using Persons.Infrastructure.Persistance.Context;

namespace Persons.Infrastructure.Repositories
{
    public class PhoneNumberRepository : GenericRepository<PhoneNumber, PersonDbContext>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(PersonDbContext context) : base(context)
        {
        }
    }
}
