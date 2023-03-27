using AutoMapper;
using MediatR;
using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate;
using System.Security.Cryptography.X509Certificates;

namespace Persons.Application.Persons.Queries.GetPersons
{
    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, IEnumerable<PersonResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetPersonsQueryHandler(
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonResponse>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = _unitOfWork.PersonRepository.GetAllBySpec(
                x => x.Name.Contains(request.Name) 
                || x.Surname.Contains(request.Surname) 
                || x.PersonalNumber.Contains(request.PersonalNumber));

            //if (!string.IsNullOrEmpty(request.ExtendedSeachQuery){
            //    persons = persons.Where(x=>x.BirthDate. == )
            //}
            var result =  _mapper.Map<IEnumerable<PersonResponse>>(persons);
            return result;
        }
    }
}
