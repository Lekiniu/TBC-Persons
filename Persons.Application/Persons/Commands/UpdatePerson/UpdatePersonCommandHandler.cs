using AutoMapper;
using MediatR;
using Persons.Application.Common.Resources;
using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate;

namespace Persons.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePersonCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(request.Id);
            if (person is null) throw new Exception(CommonResource.PersonNotFoundError);
            person.Update(request.Name, request.Surname, request.Gender, request.PersonalNumber, request.BirthDate, request.CityId);
            _unitOfWork.PersonRepository.Update(person);

            if (request.PhoneNumbers?.Count != 0)
            {
                foreach (var item in request.PhoneNumbers)
                {
                    var personNumber = person.PhoneNumbers.FirstOrDefault(x => x.Id == item.Id);
                    personNumber?.Update(item.Number);
                }
            }
            await _unitOfWork.SaveChangesAsync();
            return person.Id;
        }
    }
}

