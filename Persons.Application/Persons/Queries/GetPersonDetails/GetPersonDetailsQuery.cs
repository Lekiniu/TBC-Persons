using AutoMapper;
using MediatR;

namespace Persons.Application.Persons.Queries.GetPersonDetails
{
    public class GetPersonDetailsQuery :  IRequest<PersonDetailsModel>
    {
        public int Id { get; set; }

    }
}
