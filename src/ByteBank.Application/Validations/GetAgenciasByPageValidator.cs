namespace ByteBank.Application.Validations;

public class GetAgenciasByPageValidator
    : AbstractValidator<GetAgenciasByPage>
{
    public GetAgenciasByPageValidator()
    {
        RuleFor(gabp => gabp.PageNumber)
            .GreaterThan(0);

        RuleFor(gabp => gabp.PageSize)
            .GreaterThan(0);
    }
}