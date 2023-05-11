using ByteBank.API.Request.DTO;
using FluentValidation;

namespace ByteBank.API.Request.Validator
{
    public class UsuarioDTOValidator: AbstractValidator<UserDTO>
    {
        public UsuarioDTOValidator()
        {
            RuleFor(u=>u.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Email é obrigatório")
            .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Informe um email no formato email@email.com");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password é obrigatório");

            RuleFor(u => u.ConfirmPassaword)
                .NotEmpty().WithMessage("ConfirmPassaword é obrigatório");
        }
    }
}
