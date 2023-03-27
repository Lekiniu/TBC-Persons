using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate;

namespace Persons.Domain.AggregateModels.PersonAggregate.Interfaces
{
    public interface IPhoneNumberRepository : IGenericRepository<PhoneNumber>
    {
    }
}
