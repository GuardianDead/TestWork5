using FluentValidation;
using TestWork5.Data.Models;
using TestWork5.Data.Validators.Common;

namespace TestWork5.Data.Validators;

public class ParseDataTaskValidator : AbstractValidator<HtmlParseDataTask>
{
    public ParseDataTaskValidator(Base64Validator base64Validator)
    {
        RuleFor(p => p.Attribute)
            .NotNull().NotEmpty().WithMessage("Can not be null or empty");
        RuleFor(p => p.Selector)
            .NotNull().NotEmpty().WithMessage("Can not be null or empty");
        RuleFor(p => p.UrlBase64)
            .SetValidator(base64Validator);
        RuleFor(p => p.PageBase64)
            .SetValidator(base64Validator);
    }
}