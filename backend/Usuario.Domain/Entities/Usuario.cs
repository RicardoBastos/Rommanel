using System;

namespace Usuario.Domain.Entities
{
    public class Usuario : BaseEntity<Guid>
    {
        public Usuario()
        {

        }

        public void SetUsuario(Guid id, string nome, string email, 
            string cpf, DateTime dataNascimento,string cidade, string estado )
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Cpf = cpf;
            this.DataNascimento = dataNascimento;
            this.Cidade = cidade;
            this.Estado = estado;
            
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf{ get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
