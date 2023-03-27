using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persons.Domain.AggregateModels.PersonAggregate;

namespace Persons.Infrastructure.Persistance.Context
{
    public class PersonDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public PersonDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("PersonDb"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonDbContext).Assembly);
        }
    }
}
