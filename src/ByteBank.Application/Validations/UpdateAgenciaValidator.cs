namespace ByteBank.Application.Validations;

public class UpdateAgenciaValidator
    : AbstractValidator<UpdateAgencia>
{
    public UpdateAgenciaValidator()
    {
        RuleFor(ua => ua.Id)
            .GreaterThan(0);

        RuleFor(ua => ua.Logradouro)
            .NotEmpty();

        RuleFor(ua => ua.Cep)
            .NotEmpty();

        RuleFor(ua => ua.Numero)
            .GreaterThan(0);
    }
}