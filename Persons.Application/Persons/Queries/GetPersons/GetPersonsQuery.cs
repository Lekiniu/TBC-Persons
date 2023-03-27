using AutoMapper;
using MediatR;

namespace Persons.Application.Persons.Queries.GetPersons
{
    public class GetPersonsQuery :  IRequest<IEnumerable<PersonResponse>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalNumber { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string ExtendedSeachQuery { get; set; }

    }
}
