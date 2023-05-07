namespace ByteBank.Application.Errors;

public class ResourceNotFoundError : Error
{
    public ResourceNotFoundError(string message)
        : base(message)
    {
    }
}