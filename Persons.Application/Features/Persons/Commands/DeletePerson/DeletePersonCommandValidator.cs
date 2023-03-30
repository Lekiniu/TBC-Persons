using FluentValidation;
using System.Text.RegularExpressions;

namespace Persons.Application.Features.Persons.Commands.DeletePerson
{
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
