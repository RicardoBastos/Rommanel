using System;

namespace Usuario.Domain.Command
{
    public class AtualizarUsuarioCmd : UsuarioCmd
    {
        public AtualizarUsuarioCmd() { }

        public AtualizarUsuarioCmd(Guid id, string nome, string email, string cpf, DateTime dataNascimento, string cidade, string estado)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Cpf = cpf;
            this.DataNascimento = dataNascimento;
            this.Cidade = cidade;
            this.Estado = estado;
        }
    }
}
