namespace ByteBank.Application.Errors;

public class ValidationError : Error
{
    public ValidationError(
        IEnumerable<ValidationErrorItem> errors)
    {
        Errors = errors.ToList();
    }

    public IReadOnlyCollection<ValidationErrorItem> Errors { get; }

    public record ValidationErrorItem(
        string FieldName,
        string ErrorMessage);
}