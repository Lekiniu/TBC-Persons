using Persons.Domain.Enums;

namespace Persons.Domain.AggregateModels.PersonAggregate
{
    public class Person
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

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderTypes Gender { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string FileUrl { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
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
            if (relation !=null) _relativePersons.Remove(relation);
            return this;
        }
    }
}
