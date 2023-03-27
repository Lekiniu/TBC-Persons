using Persons.Domain.Enums;

namespace Persons.Domain.AggregateModels.PersonAggregate
{
    public class City
    {
        private readonly List<Person> _persons;
        public City()
        {
            _persons = new List<Person>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IReadOnlyCollection<Person> Persons => _persons;
    }
}
