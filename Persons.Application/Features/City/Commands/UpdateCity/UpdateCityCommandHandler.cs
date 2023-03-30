using MediatR;
using Persons.Application.Common.Resources;
using Persons.Application.Interfaces;

namespace Persons.Application.Features.City.Commands.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCityCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CityRepository.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower() && x.IsActive))
            {
                throw new Exception(CommonResource.AlreadyExist);
            }

            var city = await _unitOfWork.CityRepository.GetByIdAsync(request.Id);

            if (city is null) throw new Exception(CommonResource.NotFoundError);

            city.Update(request.Name);

            _unitOfWork.CityRepository.Update(city);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
