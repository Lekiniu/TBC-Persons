using AutoMapper;
using MediatR;
using Persons.Application.Common.Mappings;
using Persons.Application.Common.PagedList;
using TBC.Application.Features.Person.Commands.AddPersonContact;

namespace Persons.Application.Features.Persons.Queries.GetPersons
{
    public class GetPersonsQuery : MapFrom<GetPersonsModel>, IRequest<PagedList<PersonModel>>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PersonalNumber { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? ExtendedSeachQuery { get; set; }

    }
}
