using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Results;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace TestWork5.Data.Validators.Common;

public class ModelValidator<T> : IValidatableObject where T : class
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        IValidator<T>? validator = validationContext.GetService<IValidator<T>>();
        List<ValidationFailure>? errors = validator.Validate((T)validationContext.ObjectInstance).Errors;
        return errors.Select(error => new ValidationResult(error.ErrorMessage, new []{ error.PropertyName }));
    }
}