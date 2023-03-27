using Persons.Domain.AggregateModels.PersonAggregate.Interfaces;

namespace Persons.Application.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        public IPersonRepository PersonRepository { get; }
        public IPhoneNumberRepository PhoneNumberRepository { get; }
        public IPersonsRelationRepository PersonsRelationRepository { get; }
    }
}
