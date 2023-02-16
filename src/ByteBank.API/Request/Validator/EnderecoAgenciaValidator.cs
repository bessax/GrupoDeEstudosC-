using Azure;
using ByteBank.API.Request;
using FluentValidation;
using Microsoft.SqlServer.Server;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace ByteBank.API.Request.Validator
{
    public class EnderecoAgenciaValidator : AbstractValidator<EnderecoAgenciaRequest>
    {
        public EnderecoAgenciaValidator()
        {
            RuleFor(a => a.Numero)
            .NotNull()
            .WithMessage("Campo obrigatório.");

            RuleFor(a => a.Cep)
                .Matches(@"^\d{5}-\d{3}$")
                .WithMessage("O CEP deve estar no formato 00000 - 000");

            RuleFor(a => a.Logradouro)
                .NotNull()
                .WithMessage("O campo logradouro é obrigatório")
                .MinimumLength(10).WithMessage("Mínimo de 10 caracteres")
                .MaximumLength(60).WithMessage("Máximo de 60 caracteres");

            RuleFor(a => a.Complemento)
               .NotNull()
               .WithMessage("O campo número é obrigatório");
        }
    }
}
