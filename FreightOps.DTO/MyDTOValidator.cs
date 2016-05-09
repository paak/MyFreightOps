using FluentValidation;
using System;

namespace FreightOps.DTO.Validator
{
    public class MyDTOValidator : AbstractValidator<MyDTO>
    {
        public MyDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("{PropertyName} is requires")
                .Length(25);

            RuleFor(x => x.Id)
                .NotEmpty()
                    .WithMessage("Required property '{PropertyName}' not found.")
                .GreaterThan(0)
                    .WithMessage("Greater than zero.");

            RuleFor(x => x.MyDateTime)
                .NotEmpty()
                    .WithMessage("Required property '{PropertyName}' not found.")
                .GreaterThan(DateTime.MinValue)
                    .When(x => x.MyDateTime != null)
                .LessThan(DateTime.MaxValue)
                    .When(x => x.MyDateTime != null);
        }
    }
}