﻿using FluentValidation;

namespace Persons.Application.Persons.Commands.AddRelatedPerson
{
    public class AddRelatedPersonCommandValidator : AbstractValidator<AddRelatedPersonCommand>
    {
        public AddRelatedPersonCommandValidator()
        {
            RuleFor(x => x.PersonId)
            .NotEmpty();

            RuleFor(x => x.RelatedPersonId)
           .NotEmpty();

            RuleFor(x => x.RelationType)
            .NotEmpty()
            .IsInEnum();
        }
    }
}
