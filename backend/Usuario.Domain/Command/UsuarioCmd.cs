using FluentValidation.Results;
using MediatR;
using System;
using Usuario.Domain.Interfaces;
using Usuario.Domain.Validation;

namespace Usuario.Domain.Command
{
    public class UsuarioCmd : IRequest<Result>, ICommand
    {
        public Guid Id { get; protected set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public void SetId(Guid id)
        {
            this.Id = id;
        }

        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            var validation = new UsuarioValidation();
            //validation.ValidarId();
            validation.ValidarNome();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }

   
}
