using FluentValidation;

namespace TestWork5.Data.Validators.Common;

public class Base64Validator : AbstractValidator<string>
{
    public Base64Validator()
    {
        RuleFor(p => p)
            .NotNull().NotEmpty().WithMessage("Can not be null or empty")
            .Must(CanConvertFromBase64).WithMessage("Must be in 'base64' format");
    }
    
    private bool CanConvertFromBase64(string value) {

        try
        {
            Convert.FromBase64String(value);
            return true;
        }
        catch (FormatException e)
        {
            return false;
        }
    }
}