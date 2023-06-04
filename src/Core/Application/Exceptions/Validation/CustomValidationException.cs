using System.Runtime.Serialization;
using Application.Exceptions.Base;
using Application.Models.Validation;

namespace Application.Exceptions.Validation;

[Serializable]
public class CustomValidationException : AppException
{
    public CustomValidationException(ValidationError validationError) : this(new ValidationError[] { validationError },
        null)
    {
    }

    public CustomValidationException(IEnumerable<ValidationError> errors, IEnumerable<string> messages = null) : base(
        errors, messages)
    {
    }

    protected CustomValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
        base(serializationInfo, streamingContext)
    {
    }
}