using ByteBank.API.Request;
using FluentValidation;

namespace ByteBank.API.Validator;
public class AgenciaValidator: AbstractValidator<AgenciaRequest>
{
	public AgenciaValidator()
	{
		RuleFor(x => x.NomeAgencia).NotEmpty().WithMessage("Nome é obrigatório").
			Length(1, 8).WithMessage("Nome não pode ser superior a 80 caracteres.");

		RuleFor(x => x.NumeroAgencia).NotEmpty().WithMessage("Numero Agência é obrigatório");

		RuleFor(x => x.Endereco).NotNull().WithMessage("Endereço é obrigatório");
	}
}
