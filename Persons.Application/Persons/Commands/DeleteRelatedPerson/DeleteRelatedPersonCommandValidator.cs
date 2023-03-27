using FluentValidation;

namespace Persons.Application.Persons.Commands.AddRelatedPerson
{
    public class DeleteRelatedPersonCommandValidator : AbstractValidator<AddRelatedPersonCommand>
    {
        public DeleteRelatedPersonCommandValidator()
        {
            RuleFor(x => x.PersonId)
            .NotEmpty();

            RuleFor(x => x.RelatedPersonId)
           .NotEmpty();
        }
    }
}
