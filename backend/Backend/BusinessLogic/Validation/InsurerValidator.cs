

using FluentValidation;
using FluentValidation.Results;

namespace Backend.Shared;

public class InsurerValidator:AbstractValidator<Insurer>
{
    public InsurerValidator()
    {
        RuleFor(n => n.Name)
            .MaximumLength(45)
            .WithMessage("You cannot exceed the 45 digits");
        RuleFor(n => n.Commission)
            .LessThanOrEqualTo(25)
            .WithMessage("The commission cannot be bigger than 25")
            ;

        
    }

    protected override bool PreValidate(ValidationContext<Insurer> context, ValidationResult result)
    {
        if (context.InstanceToValidate!=null)
        {
            context.InstanceToValidate.Commission=decimal.Round(context.InstanceToValidate.Commission, 2, MidpointRounding.ToZero);
                ;
        }
        return true;
    }

}

