using MediatR;
using Persons.Application.Common.Resources;
using Persons.Application.Interfaces;

namespace Persons.Application.Features.City.Commands.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCityCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CityRepository.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower()))
            {
                throw new Exception(CommonResource.AlreadyExist);
            }

            var city = Domain.AggregateModels.CityAggregate.City.Create(request.Name);

            await _unitOfWork.CityRepository.AddAsync(city);
            await _unitOfWork.SaveChangesAsync();
            return city.Id;
        }
    }
}
