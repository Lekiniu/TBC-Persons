using Persons.Application.Common.Base;
using Persons.Domain.AggregateModels.PersonAggregate;
using Persons.Domain.Enums;

namespace Persons.Domain.AggregateModels.CityAggregate
{
    public class City : BaseEntity<int>
    {
        private readonly List<Person> _persons;
        public City()
        {
            _persons = new List<Person>();
        }
        private City(string name) : this()
        {
            Name = name;
        }


        public string Name { get; private set; }
        public virtual IReadOnlyCollection<Person> Persons => _persons;

        public static City Create(string name) => new City(name);

        public void Update(string name) => Name = name;
    }
}
