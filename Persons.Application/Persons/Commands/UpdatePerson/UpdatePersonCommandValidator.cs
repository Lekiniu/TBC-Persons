using FluentValidation;
using System.Text.RegularExpressions;

namespace Persons.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(2, 50)
                .Must(x =>
                (Regex.IsMatch(x, "^[a-zA-Z]*$") || Regex.IsMatch(x, "^[ა-ჰ]*$")) && 
                !string.IsNullOrEmpty(x) && 
                !string.IsNullOrWhiteSpace(x));


            RuleFor(x => x.Surname)
              .NotEmpty()
              .Length(2, 50)
              .Must(x =>
              (Regex.IsMatch(x, "^[a-zA-Z]*$") || Regex.IsMatch(x, "^[ა-ჰ]*$")) &&
              !string.IsNullOrEmpty(x) &&
              !string.IsNullOrWhiteSpace(x));


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
