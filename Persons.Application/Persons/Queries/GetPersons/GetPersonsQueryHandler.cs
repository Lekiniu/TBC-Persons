using AutoMapper;
using MediatR;
using Persons.Application.Common.PagedList;
using Persons.Application.Helpers.Filtering.Persons;
using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate;
using System.Security.Cryptography.X509Certificates;

namespace Persons.Application.Persons.Queries.GetPersons
{
    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, PagedList<PersonResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetPersonsQueryHandler(
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<PersonResponse>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            var personsSpec = new PersonSpecifications(request.Name, request.Surname, request.PersonalNumber, request.ExtendedSeachQuery).ToExpression();
            var data = await _unitOfWork.PersonRepository.GetPersonsbySpec(personsSpec);
            var result = await PagedList<PersonResponse>.Create(_unitOfWork.PersonRepository, data, request.PageNumber, request.PageSize, _mapper, cancellationToken);
            return result ?? new PagedList<PersonResponse>();
        }
    }
}
