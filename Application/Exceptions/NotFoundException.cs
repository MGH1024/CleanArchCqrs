namespace Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string name,object value ) : base($"{name} ({value}) not found")
    {
        
    }
}