namespace ByteBank.Application.Validations;

public class DeleteAgenciaValidator
    : AbstractValidator<DeleteAgencia>
{
    public DeleteAgenciaValidator()
    {
        RuleFor(da => da.Id)
            .GreaterThan(0);
    }
}