using AutoMapper;
using MediatR;
using Persons.Application.Common.Resources;
using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate;
using System;

namespace Persons.Application.Persons.Commands.AddRelatedPerson
{
    public class AddRelatedPersonHandler : IRequestHandler<AddRelatedPersonCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddRelatedPersonHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddRelatedPersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(request.PersonId);
            if(person is null) throw new Exception(CommonResource.PersonNotFoundError);

            var relatederson = await _unitOfWork.PersonRepository.GetByIdAsync(request.RelatedPersonId);
            if (relatederson is null) throw new Exception(CommonResource.PersonNotFoundError);

            person.AddRelatedPerson(request.PersonId, request.RelatedPersonId, request.RelationType);

            await _unitOfWork.PersonRepository.UpdateAsync(person);
            return person.Id;
        }
    }
}
