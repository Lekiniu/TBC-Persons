using AutoMapper;
using MediatR;
using Persons.Application.Common.PagedList;
using Persons.Application.Interfaces;

namespace Persons.Application.Features.City.Queries.GetCities
{
    public class GetCityQueryHandler : IRequestHandler<GetCityQuery, PagedList<CityModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCityQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagedList<CityModel>> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            var citiesSpec = new CitySpecification(request.Name).ToExpression();

            var data = await _unitOfWork.CityRepository.GetbySpecifications(citiesSpec);
            var pagedList = await PagedList<Domain.AggregateModels.CityAggregate.City>.Create(_unitOfWork.CityRepository, data, request.PageNumber, request.PageSize, _mapper, cancellationToken);

            return _mapper.Map<PagedList<CityModel>>(pagedList);
        }
    }
}
