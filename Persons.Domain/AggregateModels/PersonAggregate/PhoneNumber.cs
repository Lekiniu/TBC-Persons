using Persons.Application.Common.Base;
using Persons.Domain.Enums;
using System.Numerics;

namespace Persons.Domain.AggregateModels.PersonAggregate
{
    public class PhoneNumber : BaseEntity<int>
    {
        protected PhoneNumber() { 
        }
        private PhoneNumber(string number, PhoneNumberTypes phoneNumberType) : this()
        {
            Number = number;
            PhoneNumberType = phoneNumberType;
        }
        public string Number { get; private  set; }
        public int PersonId { get; private set; }
        public PhoneNumberTypes PhoneNumberType { get; private set; }
        public virtual Person Person { get; private  set; }

        public static PhoneNumber Create(string number, PhoneNumberTypes phoneNumberType)
        {
            return new PhoneNumber(number, phoneNumberType);
        }

        public void Update (string number, PhoneNumberTypes phoneNumberType)
        { 
            Number = number;
            PhoneNumberType = phoneNumberType;
         
        }
    }
}