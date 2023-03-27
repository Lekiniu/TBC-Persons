using Persons.Application.Interfaces;

namespace Persons.Domain.AggregateModels.PersonAggregate.Interfaces
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<Person?> GetPersonDetails(int id);
    }
}
