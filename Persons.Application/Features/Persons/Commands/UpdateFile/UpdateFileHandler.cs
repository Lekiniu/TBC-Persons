using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Persons.Application.Common.Resources;
using Persons.Application.Infrastructure.Services;
using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate;
using System;

namespace Persons.Application.Features.Persons.Commands.UpdateFile
{
    public class UpdateFileHandler : IRequestHandler<UpdateFileCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileServices _flieServices;
        public UpdateFileHandler(
            IUnitOfWork unitOfWork, IFileServices flieServices)
        {
            _unitOfWork = unitOfWork;
            _flieServices = flieServices;
        }

        public async Task<int> Handle(UpdateFileCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(request.PersonId);
            if (person is null) throw new Exception(CommonResource.NotFoundError);

            var fileUrl =await _flieServices.UploadFile(person.Id, request.File);

            person.AddFile(fileUrl);

            await _unitOfWork.PersonRepository.UpdateAsync(person);
            await _unitOfWork.SaveChangesAsync();
            return person.Id;
        }
      }
  }

