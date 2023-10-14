using MGH.Exceptions.Base;
using MGH.Exceptions.Models;

namespace Application.Models.Responses;

public class ApiResponse
{
    public object Data { get; set; }
    public string Message { get; set; }
    public IEnumerable<string> Messages { get; set; }
    public IEnumerable<ValidationError> ValidationMessages { get; set; }

    public ApiResponse(object data, string message = null, IEnumerable<string> messages = null,
        IEnumerable<ValidationError> validationMessages = null)
    {
        Data = data;
        Messages = messages;
        Message = message;
        ValidationMessages = validationMessages;
    }

    public ApiResponse(string message) : this(null,  message)
    {
        
    }

    public ApiResponse(IEnumerable<string> messages) : this(null,  null, messages: messages)
    {
    }
    
    public ApiResponse(GeneralException ex) : this(null, null, new List<string> { ex.Message })
    {
    }
    
    public ApiResponse(IEnumerable<string> messages, IEnumerable<ValidationError> validationMessages)
        : this(null, null, messages, validationMessages)
    {
    }
    
    
    public ApiResponse(object data, IEnumerable<string> messages) : this(data, null, messages)
    {
    }
}