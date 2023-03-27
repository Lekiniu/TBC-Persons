using FluentValidation;

namespace Persons.Application.Persons.Queries.GetPersonDetails
{
    public class GetPersonDetailsQueryValidator : AbstractValidator<GetPersonDetailsQuery>
    {
        public GetPersonDetailsQueryValidator()
        {
            RuleFor(x => x.Id).ExclusiveBetween(5, 8);
        }
    }
}
