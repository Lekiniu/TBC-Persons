using FluentValidation;

namespace Persons.Application.Features.Persons.Queries.GetPersons
{
    public class GetPersonsQueryValidator : AbstractValidator<GetPersonsQuery>
    {
        public GetPersonsQueryValidator()
        {
        }
    }
}
