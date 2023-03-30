using FluentValidation;

namespace Persons.Application.Features.City.Commands.DeleteCity
{
    public class DeleteCityCommandValidator : AbstractValidator<DeleteCityCommand>
    {
        public DeleteCityCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
