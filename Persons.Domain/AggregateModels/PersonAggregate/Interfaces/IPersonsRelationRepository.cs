using Persons.Application.Interfaces;

namespace Persons.Domain.AggregateModels.PersonAggregate.Interfaces
{
    public interface IPersonsRelationRepository : IGenericRepository<PersonsRelation>
    {
    }
}
