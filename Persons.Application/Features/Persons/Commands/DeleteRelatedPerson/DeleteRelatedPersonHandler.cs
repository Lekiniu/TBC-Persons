using AutoMapper;
using MediatR;
using Persons.Application.Common.Resources;
using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate;
using System;

namespace Persons.Application.Features.Persons.Commands.DeleteRelatedPerson
{
    public class DeleteRelatedPersonHandler : IRequestHandler<DeleteRelatedPersonCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteRelatedPersonHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteRelatedPersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(request.PersonId);
            if (person is null || !person.IsActive) throw new Exception(CommonResource.NotFoundError);

            var relatedPerson = await _unitOfWork.PersonRepository.GetByIdAsync(request.RelatedPersonId);
            if (relatedPerson is null || !person.IsActive) throw new Exception(CommonResource.NotFoundError);

            person.DeleteRelatedPerson(request.PersonId, request.RelatedPersonId);
            await  _unitOfWork.PersonRepository.UpdateAsync(person, cancellationToken);
            return Unit.Value;
        }
    }
}
