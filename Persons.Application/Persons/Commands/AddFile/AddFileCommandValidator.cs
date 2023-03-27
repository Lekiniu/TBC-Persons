using FluentValidation;

namespace Persons.Application.Persons.Commands.CreatePerson
{
    public class AddFileCommandValidator : AbstractValidator<AddFileCommand>
    {
        public AddFileCommandValidator()
        {
            RuleFor(x => x.PersonId)
            .NotEmpty();
            RuleFor(x => x.File)
           .NotEmpty();
        }
    }
}
