using ByteBank.API.Request;
using FluentValidation;

namespace ByteBank.API.Request.Validator;
public class AgenciaValidator : AbstractValidator<AgenciaRequest>
{
    public AgenciaValidator()
    {
        RuleFor(x => x.NomeAgencia)
            .NotNull()
            .NotEmpty().WithMessage("Nome é obrigatório").
            Length(1, 80)
            .WithMessage("Nome não pode ser superior a 80 caracteres.");

        RuleFor(x => x.NumeroAgencia).NotEmpty().WithMessage("Numero Agência é obrigatório");

        RuleFor(x => x.Endereco)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("Endereço é obrigatório")
            .SetValidator(new EnderecoValidator());
    }
}
