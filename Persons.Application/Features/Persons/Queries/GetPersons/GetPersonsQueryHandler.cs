using AutoMapper;
using MediatR;
using Persons.Application.Common.PagedList;
using Persons.Application.Helpers.Filtering.Persons;
using Persons.Application.Interfaces;

namespace Persons.Application.Features.Persons.Queries.GetPersons
{
    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, PagedList<PersonModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetPersonsQueryHandler(
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<PersonModel>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            var personsSpec = new PersonSpecifications(request.Name, request.Surname, request.PersonalNumber, request.ExtendedSeachQuery).ToExpression();
            var data = await _unitOfWork.PersonRepository.GetPersonsbySpec(personsSpec);
            var result = await PagedList<PersonModel>.Create(_unitOfWork.PersonRepository, data, request.PageNumber, request.PageSize, _mapper, cancellationToken);
            return result ?? new PagedList<PersonModel>();
        }
    }
}
