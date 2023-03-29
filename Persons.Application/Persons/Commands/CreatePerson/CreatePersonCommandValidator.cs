using FluentValidation;
using Persons.Application.Common.Resources;
using System.Text.RegularExpressions;

namespace Persons.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(2, 50)
                .Must(x =>
                (Regex.IsMatch(x, "^[a-zA-Z]*$") || Regex.IsMatch(x, "^[ა-ჰ]*$")) && 
                !string.IsNullOrEmpty(x) && 
                !string.IsNullOrWhiteSpace(x)).WithMessage(CommonResource.LanguageError);


            RuleFor(x => x.Surname)
              .NotEmpty()
              .Length(2, 50)
              .Must(x =>
              (Regex.IsMatch(x, "^[a-zA-Z]*$") || Regex.IsMatch(x, "^[ა-ჰ]*$")) &&
              !string.IsNullOrEmpty(x) &&
              !string.IsNullOrWhiteSpace(x)).WithMessage(CommonResource.LanguageError);


            RuleFor(x => x.PersonalNumber)
             .NotEmpty()
             .Length(11)
             .Must(x =>Regex.IsMatch(x, "^[0-9]*$"));

            RuleFor(x => x.BirthDate)
            .NotEmpty()
            .Must(x => DateTime.Now.Year - x.Year >= 18);

            RuleFor(x => x.Gender)
            .NotEmpty()
            .IsInEnum();
        }
    }
}
