using Persons.Domain.AggregateModels.PersonAggregate;
using Persons.Domain.AggregateModels.PersonAggregate.Interfaces;
using Persons.Infrastructure.Persistance.Context;

namespace Persons.Infrastructure.Repositories
{
    public class PersonsRelationRepository : GenericRepository<PersonsRelation, PersonDbContext>, IPersonsRelationRepository
    {
        public PersonsRelationRepository(PersonDbContext context) : base(context)
        {
       
        }
    }
}
