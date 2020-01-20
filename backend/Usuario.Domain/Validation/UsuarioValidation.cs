using FluentValidation;
using Usuario.Domain.Command;

namespace Usuario.Domain.Validation
{
    public class UsuarioValidation : AbstractValidator<UsuarioCmd>
    {
        public void ValidarId()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("O Id precisa ser maior que zero");
        }

        public void ValidarNome()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Nome não pode estar vazio")
                .MaximumLength(150).WithMessage("Nome permitido apenas 150 caracteres");
        }
    }
}
