using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Persons.Application.Common.Resources;
using Persons.Application.Infrastructure.Services;
using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate;
using System;

namespace Persons.Application.Persons.Commands.CreatePerson
{
    public class AddFileHandler : IRequestHandler<AddFileCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileServices _flieServices;
        public AddFileHandler(
            IUnitOfWork unitOfWork, IFileServices flieServices)
        {
            _unitOfWork = unitOfWork;
            _flieServices = flieServices;
        }

        public async Task<int> Handle(AddFileCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(request.PersonId);
            if (person is null) throw new Exception(CommonResource.PersonNotFoundError);

            var fileUrl =await _flieServices.UploadFile(person.Id, request.File);

            person.AddFile(fileUrl);

            await _unitOfWork.PersonRepository.UpdateAsync(person);
            await _unitOfWork.SaveChangesAsync();
            return person.Id;
        }
      }
  }

