using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Persons.Application.Features.Persons.Queries.GetPersonDetails
{
    public class GetPersonDetailsQuery :  IRequest<PersonDetailsModel>
    {
        
        public int Id { get; set; }
    }
}
