using FluentValidation;

namespace Persons.Application.Features.Persons.Commands.UpdateFile
{
    public class UpdateFileCommandValidator : AbstractValidator<UpdateFileCommand>
    {
        public UpdateFileCommandValidator()
        {
            RuleFor(x => x.PersonId)
            .NotEmpty();
            RuleFor(x => x.File)
           .NotEmpty();
        }
    }
}
