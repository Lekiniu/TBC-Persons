using AutoMapper;
using MediatR;
using Persons.Application.Common.Resources;
using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate;
using System;

namespace Persons.Application.Persons.Commands.AddRelatedPerson
{
    public class DeleteRelatedPersonHandler : IRequestHandler<DeleteRelatedPersonCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteRelatedPersonHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteRelatedPersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(request.PersonId);
            if(person is null) throw new Exception(CommonResource.PersonNotFoundError);

            var relatedPerson = await _unitOfWork.PersonRepository.GetByIdAsync(request.RelatedPersonId);
            if (relatedPerson is null) throw new Exception(CommonResource.PersonNotFoundError);

            //var relation =   person.RelativePersons.FirstOrDefault(x => x.MainPersonId == request.PersonId && x.RelatedPersonId == request.RelatedPersonId);
            //if (relation is null) throw new Exception(CommonResource.PersonNotFoundError);

            person.DeleteRelatedPerson(request.PersonId, request.RelatedPersonId);
            _unitOfWork.PersonRepository.Update(person);
            await _unitOfWork.SaveChangesAsync();
            return person.Id;
        }
    }
}
