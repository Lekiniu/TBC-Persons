using MediatR;
using Persons.Application.Common.Resources;
using Persons.Application.Interfaces;

namespace Persons.Application.Features.City.Commands.DeleteCity
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCityCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWork.CityRepository.GetByIdAsync(request.Id);

            if (city is null) throw new Exception(CommonResource.NotFoundError);

            city.Delete();

            _unitOfWork.CityRepository.Update(city);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
