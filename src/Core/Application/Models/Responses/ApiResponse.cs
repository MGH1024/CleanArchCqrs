using MGH.Exceptions.Base;
using MGH.Exceptions.Models;

namespace Application.Models.Responses;

public class ApiResponse
{
    public object Data { get; set; }
    public IEnumerable<string> Messages { get; set; }
    public IEnumerable<ValidationError> ValidationMessages { get; set; }
    
    public ApiResponse(object data, IEnumerable<string> messages, IEnumerable<ValidationError> validationMessages)
    {
        Data = data;
        Messages = messages;
        ValidationMessages = validationMessages;
    }

    public ApiResponse() : this(null, null, null)
    {
    }

    public ApiResponse(IEnumerable<string> messages)
        : this(null, messages: messages , null)
    {

    }
    
    public ApiResponse(GeneralException ex)
        : this(null, new List<string> { ex.Message }, null)
    {

    }

    public ApiResponse(IEnumerable<string> messages, IEnumerable<ValidationError> validationMessages)
        : this(null, messages, validationMessages)
    {

    }
    
    public ApiResponse(object data)
        : this(data, null,null)
    {
    }
    
    public ApiResponse(object data,IEnumerable<string> messages)
        : this(data, messages,null)
    {
    }
}