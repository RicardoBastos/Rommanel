using System;

namespace Usuario.Domain.Command
{
    public class InserirUsuarioCmd : UsuarioCmd
    {
        public InserirUsuarioCmd() { }

        public InserirUsuarioCmd(string nome, string email,string cpf, DateTime dataNascimento, string cidade, string estado)
        {
            this.Nome = nome;
            this.Email = email;
            this.Cpf = cpf;
            this.DataNascimento = dataNascimento;
            this.Cidade = cidade;
            this.Estado = estado;
        }
    }
}
