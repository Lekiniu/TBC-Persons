using Persons.Domain.AggregateModels.CityAggregate.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate.Interfaces;

namespace Persons.Application.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public IPersonRepository PersonRepository { get; }
        public ICityRepository CityRepository { get; }
    }
}
