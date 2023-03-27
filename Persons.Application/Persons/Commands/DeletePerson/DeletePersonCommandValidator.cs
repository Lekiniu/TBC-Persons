using FluentValidation;
using System.Text.RegularExpressions;

namespace Persons.Application.Persons.Commands.CreatePerson
{
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
