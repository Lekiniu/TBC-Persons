using FluentValidation;

namespace Persons.Application.Features.Persons.Commands.AddFile
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
