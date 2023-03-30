using Microsoft.EntityFrameworkCore;
using Persons.Domain.AggregateModels.PersonAggregate;
using Persons.Domain.AggregateModels.PersonAggregate.Interfaces;
using Persons.Infrastructure.Persistance.Context;

namespace Persons.Infrastructure.Repositories
{
    public class PersonRepository : GenericRepository<Person, PersonDbContext>, IPersonRepository
    {
        public PersonRepository(PersonDbContext context) : base(context)
        {      
        }

        public async Task<Person?> GetPersonDetails(int id)
        {
            var result = await _context.Set<Person>()
                .Include(x => x.City)
                .Include(x => x.PhoneNumbers)
                .Include(x => x.RelativePersons)
                .ThenInclude(x => x.RelatedPerson)
                .FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }
    }
}
