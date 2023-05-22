namespace ByteBank.Application.Validations;

public class GetAgenciaByIdValidator
    : AbstractValidator<GetAgenciaById>
{
    public GetAgenciaByIdValidator()
    {
        RuleFor(gabi => gabi.Id)
            .GreaterThan(0);
    }
}