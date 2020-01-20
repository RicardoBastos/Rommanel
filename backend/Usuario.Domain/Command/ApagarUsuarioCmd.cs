using Usuario.Domain.Validation;

namespace Usuario.Domain.Command
{
    public class ApagarUsuarioCmd : UsuarioCmd
    {
        public ApagarUsuarioCmd(int id) =>
            this.Id = id;

        public override bool IsValid()
        {
            var validation = new UsuarioValidation();
            validation.ValidarId();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
