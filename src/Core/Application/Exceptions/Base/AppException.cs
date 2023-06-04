using System.Runtime.Serialization;
using Application.Models.Validation;

namespace Application.Exceptions.Base;

[Serializable]
public class AppException : Exception
{
    public AppException(string message) : this(null, new List<string> { message })
    {
    }

    public AppException(IEnumerable<string> messages) : this(errors: null, messages: messages)
    {
        Messages = messages;
    }

    public AppException(IEnumerable<ValidationError> errors, IEnumerable<string> messages) : base()
    {
        Errors = errors;
        Messages = messages;
    }

    public AppException() : base()
    {
    }

    protected AppException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public IEnumerable<ValidationError> Errors { get; }
    public IEnumerable<string> Messages { get; }
    public string ErrorsString
    {
        get
        {
            if (Errors.Any())
                return string.Join("\n", Errors.Select(x => $"'{x.PropName}' : '{x.Message}'"));

            return string.Empty;
        }
    }
}