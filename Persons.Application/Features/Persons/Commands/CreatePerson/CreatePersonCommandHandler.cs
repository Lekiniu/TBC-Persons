using AutoMapper;
using MediatR;
using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate;

namespace Persons.Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePersonCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = Person.Create(request.Name, request.Surname, request.Gender, request.PersonalNumber, request.BirthDate, request.CityId);
            await _unitOfWork.PersonRepository.AddAsync(person);
            return person.Id;
        }
    }
}
