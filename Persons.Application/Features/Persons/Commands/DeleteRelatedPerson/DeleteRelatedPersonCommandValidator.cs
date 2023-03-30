using FluentValidation;

namespace Persons.Application.Features.Persons.Commands.DeleteRelatedPerson
{
    public class DeleteRelatedPersonCommandValidator : AbstractValidator<DeleteRelatedPersonModel>
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
