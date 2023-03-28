﻿using Persons.Application.Common.Mappings;
using Persons.Application.Common.Models;
using Persons.Domain.AggregateModels.PersonAggregate;
using Persons.Domain.Enums;

namespace Persons.Application.Persons.Queries.GetPersonDetails
{
    public class PersonDetailsModel : MapFrom<Person>
    {
        public PersonDetailsModel()
        {
            PhoneNumbers = new List<PhoneNumberModel>();
            RelatedPersons = new List<RelatedPersonDetails>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderTypes Gender { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public CityModel City { get; set; }
        public byte[] File { get; set; }
        public List<PhoneNumberModel> PhoneNumbers { get; set; }
        public List<RelatedPersonDetails> RelatedPersons { get; set; }

    }
}
