using Microsoft.EntityFrameworkCore;
using Persons.Application.Helpers.Filtering.Persons;
using Persons.Domain.AggregateModels.PersonAggregate;
using Persons.Domain.AggregateModels.PersonAggregate.Interfaces;
using Persons.Infrastructure.Persistance.Context;
using System.Linq;
using System.Linq.Expressions;

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


        public async Task<IQueryable<Person>> GetPersonsbySpec(List<Expression<Func<Person, bool>>> expressions)
        {

            var result = _context.Set<Person>().AsNoTracking().AsQueryable();
            if (expressions.Count > 0)
            {
                foreach (var exp in expressions)
                {

                    result = result.Where(exp);
                }
            }
            return result;
        }

    }
}
