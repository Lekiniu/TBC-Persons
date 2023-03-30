using Persons.Application.Interfaces;
using System.Linq.Expressions;

namespace Persons.Domain.AggregateModels.PersonAggregate.Interfaces
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<Person?> GetPersonDetails(int id);
        //Task<IQueryable<Person>> GetPersonsbySpec(List<Expression<Func<Person, bool>>> expressions);
    }
}
