using MediatR;
using Persons.Application.Common.Resources;
using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate;

namespace TBC.Application.Features.Person.Commands.AddPersonContact
{
    public class AddPhoneNumberCommandHandler : IRequestHandler<AddPhoneNumberCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddPhoneNumberCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddPhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetPersonDetails(request.PersonId);
            if (person is null) throw new Exception(CommonResource.NotFoundError);

            person.AddPhoneNumber(PhoneNumber.Create(request.PhoneNumber, request.PhoneNumberType));

            await _unitOfWork.PersonRepository.UpdateAsync(person);
            return Unit.Value;
        }
    }
}
