using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persons.Application.Infrastructure.Services;
using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate.Interfaces;
using Persons.Infrastructure.Persistance.Context;
using Persons.Infrastructure.Persistance.UnitOfWork;
using Persons.Infrastructure.Repositories;
using Persons.Infrastructure.Services;

namespace Persons.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersonDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddScoped<IFileServices, FileServices>();
            return services;
        }
    }
}
