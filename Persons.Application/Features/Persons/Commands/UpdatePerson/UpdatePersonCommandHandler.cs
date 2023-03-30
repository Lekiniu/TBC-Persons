using MediatR;
using Persons.Application.Common.Resources;
using Persons.Application.Interfaces;

namespace Persons.Application.Features.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePersonCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(request.Id);
            if (person is null || !person.IsActive) throw new Exception(CommonResource.NotFoundError);
            person.Update(request.Name, request.Surname, request.Gender, request.PersonalNumber, request.BirthDate, request.CityId);
          
            if (request.PhoneNumbers != null )
            {
                foreach (var item in request.PhoneNumbers)
                {
                    person.UpdatePhoneNumber(item.Id, item.Number, item.PhoneNumberType);
                }
            }
            await _unitOfWork.PersonRepository.UpdateAsync(person);
            return Unit.Value;
        }
    }
}

