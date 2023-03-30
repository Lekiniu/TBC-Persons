using Persons.Application.Common.Base;
using Persons.Domain.AggregateModels.CityAggregate;
using Persons.Domain.Enums;

namespace Persons.Domain.AggregateModels.PersonAggregate
{
    public class Person : BaseEntity<int>
    {
        private readonly List<PhoneNumber> _phoneNumbers;
        private readonly List<PersonsRelation> _mainPersons;
        private readonly List<PersonsRelation> _relativePersons;
        public Person()
        {
            _phoneNumbers = new List<PhoneNumber>();
            _mainPersons = new List<PersonsRelation>();
            _relativePersons = new List<PersonsRelation>();
        }

        public Person(string name, string surname, GenderTypes gender, string personalNumber, DateTime birthDate, int cityId)
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            PersonalNumber = personalNumber; 
            BirthDate = birthDate;
            CityId = cityId;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public GenderTypes Gender { get; private  set; }
        public string PersonalNumber { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string? FileUrl { get; set; }
        public int CityId { get; set; }
        public virtual City City { get;  set; }
        public virtual IReadOnlyCollection<PhoneNumber> PhoneNumbers => _phoneNumbers;
        public virtual IReadOnlyCollection<PersonsRelation> MainPersons => _mainPersons;
        public virtual IReadOnlyCollection<PersonsRelation> RelativePersons => _relativePersons;

        public static Person Create(string name, string surname, GenderTypes gender, string personalNumber, DateTime birthDate, int cityId)
                             => new Person(name, surname, gender, personalNumber,birthDate, cityId);

        public  Person Update(string name, string surname, GenderTypes gender, string personalNumber,DateTime birthDate,
        int cityId)
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            PersonalNumber = personalNumber;
            BirthDate = birthDate;
            CityId = cityId;
            return this;
        }

        public  Person AddFile(string fileUrl)
        {
            FileUrl =  fileUrl;
            return this;
        }

        public Person AddRelatedPerson(int personId, int relatedPersonId, RelationTypes relationType)
        {
            var relatedPerson = PersonsRelation.Create(personId, relatedPersonId, relationType);
            _relativePersons.Add(relatedPerson);
            return this;
        }

        public Person DeleteRelatedPerson(int personId, int relatedPersonId)
        {
           var relation =  _relativePersons.FirstOrDefault(x=>x.MainPersonId == personId && x.RelatedPersonId == relatedPersonId);
            if (relation is null) throw new Exception(); 
            relation.Delete();
            return this;
        }


        public void AddPhoneNumber(PhoneNumber phoneNumber)
        {
            if (!_phoneNumbers.Any(x => x.Number == phoneNumber.Number && x.IsActive))
                _phoneNumbers.Add(phoneNumber);
        }

        public void UpdatePhoneNumber(int phoneNumberId, string number, PhoneNumberTypes phoneNumberType)
        {
            var phoneNumber = PhoneNumbers.FirstOrDefault(x => x.Id == phoneNumberId);

            if (phoneNumber == null) throw new Exception();

            phoneNumber.Update(number, phoneNumberType);
        }
    }
}
