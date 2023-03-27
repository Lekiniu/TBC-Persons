using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Persons.Application.Common.Resources;
using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate;
using System;

namespace Persons.Application.Persons.Commands.CreatePerson
{
    public class AddFileHandler : IRequestHandler<AddFileCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _appEnvironment;
        public AddFileHandler(
            IUnitOfWork unitOfWork, IWebHostEnvironment appEnvironment)
        {
            _unitOfWork = unitOfWork;
            _appEnvironment = appEnvironment;
        }

        public async Task<int> Handle(AddFileCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(request.PersonId);
            if (person is null) throw new Exception(CommonResource.PersonNotFoundError);

            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");

            var fileNameLength = request.File.FileName.Length > 10 ? request.File.FileName.Substring(request.File.FileName.Length - 10) : request.File.FileName;
            string FileName = request.PersonId + GuidString + fileNameLength;
            string filePath = @"\Files\";
            var path = Path.Combine(_appEnvironment.WebRootPath + filePath + FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }
            var fileUrl = @"/Files/" + FileName;

            person.AddFile(fileUrl);

            await _unitOfWork.PersonRepository.UpdateAsync(person);
            await _unitOfWork.SaveChangesAsync();
            return person.Id;
        }
      }
  }

