namespace ByteBank.Application.Errors;

public class ConflictError : Error
{
    public ConflictError(IEnumerable<ConflictErrorItem> errors)
    {
        Errors = errors;
    }

    public IEnumerable<ConflictErrorItem> Errors { get; }

    public record ConflictErrorItem(string Key, string Message);
}