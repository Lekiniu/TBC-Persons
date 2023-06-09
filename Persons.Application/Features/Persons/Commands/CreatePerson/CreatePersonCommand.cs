﻿using MediatR;
using Persons.Application.Common.Mappings;
using Persons.Domain.Enums;

namespace Persons.Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonCommand : MapFrom<CreatePersonModel>, IRequest<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderTypes Gender { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
       
    }
}
