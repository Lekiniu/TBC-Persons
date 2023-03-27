namespace Persons.Domain.AggregateModels.PersonAggregate
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get;  set; }


        public void Update (string number)
        {
            Number = number;
        }

    }
}
