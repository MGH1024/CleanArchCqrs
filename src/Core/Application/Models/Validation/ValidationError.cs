namespace Application.Models.Validation;

public class ValidationError
{
    public ValidationError(string propName, string message)
    {
        PropName = propName;
        Message = message;
    }
    public string PropName { get; }
    public string Message { get; }
}