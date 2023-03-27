using AutoMapper;
using MediatR;
using Persons.Application.Common.Resources;
using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate;

namespace Persons.Application.Persons.Commands.CreatePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePersonCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(request.Id);
            if (person is null) throw new Exception(CommonResource.PersonNotFoundError);
            await _unitOfWork.PersonRepository.DeleteAsync(person);
            return Unit.Value;
        }
    }
}
