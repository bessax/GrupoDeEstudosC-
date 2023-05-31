using FluentValidation;

namespace ByteBank.API.Request.Validator;
public class ContaValidator : AbstractValidator<ContaRequest>
{
    private string email = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
    private string cpf = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";
    private string cnpj = @"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$";
    private string celular = @"^(?:(?:\+|00)55\s?)?(?:\(?([1-9][0-9])\)?\s?)?(?:(9\d{4})\-?(\d{4}))$";

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
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("A chave pix é obrigatória")
            .Matches($"{email}|{cpf}|{cnpj}|{celular}")
            .WithMessage("Formato de Pix incorreto! CPF: formato 000.000.000-00, CNPJ: formato 11.222.333/4444-55, Email: formato email@email.com, Tel: formato (xx) xxxxx-xxxx");

        RuleFor(c => c.Tipo)
            .IsInEnum()
            .WithMessage("Expecifique: 0 - Conta Corrente, 1 - Conta Poupança");

        RuleFor(c => c.AgenciaId)
            .GreaterThan(0)
            .WithMessage("O id da agência deve ser maior que zero");
    }
}
