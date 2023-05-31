using FluentValidation;

namespace ByteBank.API.Request.Validator
{
    public class EnderecoValidator : AbstractValidator<EnderecoRequest>
    {
        public EnderecoValidator()
        {

            RuleFor(a => a.Cep)
                .Matches(@"^\d{5}-\d{3}$")
                .WithMessage("O CEP deve estar no formato 00000 - 000");

            RuleFor(a => a.Logradouro)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo logradouro é obrigatório")
                .Length(10, 20)
                .WithMessage("Mínimo de 10 caracteres, Máximo de 20 caracteres");

            RuleFor(a => a.Numero)
               .NotNull()
               .WithMessage("O campo número é obrigatório")
               .GreaterThanOrEqualTo(0)
               .WithMessage("O número não deve ser negativo");

            When(a => !string.IsNullOrEmpty(a.Complemento), () =>
            {
                RuleFor(a => a.Complemento)
                    .Length(5, 20)
                    .WithMessage("Mínimo de 5 caracteres, Máximo de 20 caracteres");
            });
        }
    }

}