using FluentValidation;

namespace Persons.Application.Persons.Queries.GetPersons
{
    public class GetPersonsQueryValidator : AbstractValidator<GetPersonsQuery>
    {
        public GetPersonsQueryValidator()
        {
        }
    }
}
