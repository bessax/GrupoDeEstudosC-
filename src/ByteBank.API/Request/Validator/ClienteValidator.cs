using ByteBank.API.Request;
using FluentValidation;

namespace ByteBank.API.Request.Validator;

public class ClienteValidator : AbstractValidator<ClienteRequest>
{
    public ClienteValidator()
    {
        RuleFor(c => c.Cpf)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("CPF é obrigatório")
            .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$").WithMessage("Informe o CPF no formato 000.000.000-00");

        RuleFor(c => c.Nome)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .Length(3, 30).WithMessage("Mínimo de 3 caracteres, máximo de 30 caracteres");
        RuleFor(c => c.Tipo)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Tipo cliente é obrigatório")
            .IsInEnum().WithMessage("Expecifique - PessoaFísica = 0, Cnpj = 1");

        RuleForEach(c => c.Contas)
            .SetValidator(new ContaValidator());

        RuleFor(c => c.Endereco)
            .SetValidator(new EnderecoValidator());
    }
}
