using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace TestWork5.Data.Validators.Common;

public class ModelValidator<T> : IValidatableObject where T : class
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validator = validationContext.GetService<IValidator<T>>();
        var errors = validator.Validate((T)validationContext.ObjectInstance).Errors;
        return errors.Select(error => new ValidationResult(error.ErrorMessage, new []{ error.PropertyName }));
    }
}