using FluentValidation;

namespace Persons.Application.Features.Persons.Queries.GetPersonDetails
{
    public class GetPersonDetailsQueryValidator : AbstractValidator<GetPersonDetailsQuery>
    {
        public GetPersonDetailsQueryValidator()
        {
            RuleFor(x => x.Id);
        }
    }
}
