using AutoMapper;
using MediatR;
using Persons.Application.Common.Models;
using Persons.Application.Common.Resources;
using Persons.Application.Interfaces;
using Persons.Application.Persons.Queries.GetPersons;
using Persons.Domain.AggregateModels.PersonAggregate;

namespace Persons.Application.Persons.Queries.GetPersonDetails
{
    public class GetPersonDetailsQueryHandler : IRequestHandler<GetPersonDetailsQuery, PersonDetailsModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetPersonDetailsQueryHandler(
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PersonDetailsModel> Handle(GetPersonDetailsQuery request, CancellationToken cancellationToken)
        {
           // throw new Exception("error 500");
            var person =  await _unitOfWork.PersonRepository.GetPersonDetails(request.Id);
            if(person is null) throw new Exception(CommonResource.PersonNotFoundError);
            var result = _mapper.Map<PersonDetailsModel>(person);
            var relatedPersons = person?.RelativePersons.Select(x=>x.RelatedPerson);
            result.RelatedPersons = _mapper.Map<List<RelatedPersonDetails>>(relatedPersons);
            return result;
        }
    }
}
