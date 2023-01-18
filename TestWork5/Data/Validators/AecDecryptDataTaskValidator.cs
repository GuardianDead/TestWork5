using FluentValidation;
using TestWork5.Data.Models;
using TestWork5.Data.Validators.Common;

namespace TestWork5.Data.Validators;

public class AecDecryptDataTaskValidator : AbstractValidator<AesDecryptDataTask>
{
    public AecDecryptDataTaskValidator(Base64Validator base64Validator)
    {
        RuleFor(p => p.EncryptedTextBytesBase64)
            .SetValidator(base64Validator);
        RuleFor(p => p.KeyBytesBase64)
            .SetValidator(base64Validator);
    }
}