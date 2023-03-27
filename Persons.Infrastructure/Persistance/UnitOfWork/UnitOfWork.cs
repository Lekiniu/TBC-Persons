using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate.Interfaces;
using Persons.Infrastructure.Persistance.Context;

namespace Persons.Infrastructure.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonDbContext _dbContext;
       

        public UnitOfWork(PersonDbContext dbContext, IPersonRepository personRepository, IPhoneNumberRepository phoneNumberRepository, IPersonsRelationRepository personsRelationRepositor,
            ICityRepository cityRepository)
        {
            _dbContext = dbContext;
            PersonRepository = personRepository;
            PhoneNumberRepository = phoneNumberRepository;
            PersonsRelationRepository = personsRelationRepositor;
            CityRepository = cityRepository;
        }
        public  IPersonRepository PersonRepository { get; }
        public IPhoneNumberRepository PhoneNumberRepository { get; }
        public IPersonsRelationRepository PersonsRelationRepository { get; }
        public ICityRepository CityRepository { get; }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
