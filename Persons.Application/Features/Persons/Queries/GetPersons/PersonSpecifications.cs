using Persons.Domain.AggregateModels.PersonAggregate;
using System.Drawing;
using System.Linq.Expressions;

namespace Persons.Application.Features.Persons.Queries.GetPersons
{
    public class PersonSpecifications
    {
        private Expression<Func<Person, bool>> BaseExpression { get; set; } = u => u.IsActive;
        public PersonSpecifications(string? name, string? surname, string? personalNumber, string? extendedQuery)
        {
            Name = name;
            Surname = surname;
            PersonalNumber = personalNumber;
            ExtendedQuery = extendedQuery;
        }

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PersonalNumber { get; set; }
        public string? ExtendedQuery { get; set; }


        public List<Expression<Func<Person, bool>>> ToExpression()
        {
            List<Expression<Func<Person, bool>>> expressions = new List<Expression<Func<Person, bool>>>
            {
                BaseExpression
            };

            if (!string.IsNullOrWhiteSpace(Name))
            {
                expressions.Add(x => x.Name.ToLower().Contains(Name.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(Surname))
            {
                expressions.Add(x => x.Surname.ToLower().Contains(Surname.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(PersonalNumber))
            {
                expressions.Add(x => x.PersonalNumber.ToLower().Contains(PersonalNumber.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(ExtendedQuery))
            {
                expressions.Add(x => x.BirthDate.Day.ToString() == ExtendedQuery
                || x.City.Name.ToLower().Contains(ExtendedQuery));
            }
            return expressions;
        }
    }
}
