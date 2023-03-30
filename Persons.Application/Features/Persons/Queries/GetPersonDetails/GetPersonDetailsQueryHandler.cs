using AutoMapper;
using MediatR;
using Persons.Application.Common.Models;
using Persons.Application.Common.Resources;
using Persons.Application.Infrastructure.Services;
using Persons.Application.Interfaces;

namespace Persons.Application.Features.Persons.Queries.GetPersonDetails
{
    public class GetPersonDetailsQueryHandler : IRequestHandler<GetPersonDetailsQuery, PersonDetailsModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileServices _flieServices;
        public GetPersonDetailsQueryHandler(
            IUnitOfWork unitOfWork, IMapper mapper, IFileServices flieServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _flieServices = flieServices;
        }

        public async Task<PersonDetailsModel> Handle(GetPersonDetailsQuery request, CancellationToken cancellationToken)
        {
           // throw new Exception("error 500");
            var person =  await _unitOfWork.PersonRepository.GetPersonDetails(request.Id);
            if(person is null) throw new Exception(CommonResource.NotFoundError);

            var result = _mapper.Map<PersonDetailsModel>(person);
            var relatedPersons = person?.RelativePersons.Select(x=>x.RelatedPerson);
            result.RelatedPersons = _mapper.Map<List<RelatedPersonDetails>>(relatedPersons);
            result.File = await _flieServices.DownloadFile(person.FileUrl);
            return result;
        }
    }
}
