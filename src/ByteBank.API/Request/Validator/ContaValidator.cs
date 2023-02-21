using FluentValidation;

namespace ByteBank.API.Request.Validator;
public class ContaValidator : AbstractValidator<ContaRequest>
{
    public ContaValidator()
    {
        RuleFor(c => c.NumeroConta)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("O número da conta é obrigatório")
            .Matches(@"^\d{4}-\d{4}-\d{4}-\d{4}$")
            .WithMessage("O número da conta deve estar no formato 0000-0000-0000-0000");

        RuleFor(c => c.Saldo)
            .GreaterThan(0)
            .WithMessage("Obrigatório saldo inicial");

        RuleFor(c => c.ChavePix)
            .NotEmpty()
            .WithMessage("A chave pix é obrigatória");

        RuleFor(c => c.Tipo)
            .IsInEnum()
            .WithMessage("Expecifique: 0 - Conta Corrente, 1 - Conta Poupança");

        RuleFor(c => c.AgenciaId)
            .GreaterThan(0)
            .WithMessage("O id da agência deve ser maior que zero");
    }
}
