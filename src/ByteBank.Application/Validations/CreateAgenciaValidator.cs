namespace ByteBank.Application.Validations;

public class CreateAgenciaValidator
    : AbstractValidator<CreateAgencia>
{
    public CreateAgenciaValidator()
    {
        RuleFor(ca => ca.Nome)
            .NotEmpty();

        RuleFor(ca => ca.Logradouro)
            .NotEmpty();

        RuleFor(ca => ca.Cep)
            .NotEmpty();

        RuleFor(ca => ca.Numero)
            .GreaterThan(0);
    }
}