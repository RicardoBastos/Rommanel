using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Usuario.Infrastructure.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario.Domain.Entities.Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario.Domain.Entities.Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Nome).IsRequired().HasColumnType("varchar(150)");
            builder.Property(t => t.Email).IsRequired().HasColumnType("varchar(100)");
            builder.Property(t => t.Cpf).IsRequired().HasColumnType("varchar(15)");
            builder.Property(t => t.Cidade).IsRequired().HasColumnType("varchar(70)");
            builder.Property(t => t.Estado).IsRequired().HasColumnType("varchar(50)");
            builder.Property(t => t.DataNascimento).HasColumnType("datetime");

            builder.HasData(
                new Domain.Entities.Usuario {
                    Id = 1,
                    Nome = "Ricardo Bastos",
                    DataNascimento = DateTime.Now,
                    Email ="ricardo@ricardo.com",
                    Cpf="123.456.789-8",
                    Cidade="Sao Jose",
                    Estado="São Paulo"
                },
                new Domain.Entities.Usuario { Id = 2,
                    Nome = "José Francisco",
                    Email = "ricardo@ricardo.com",
                    DataNascimento = DateTime.Now,
                    Cpf = "123.456.789-8",
                    Cidade = "Sao Jose",
                    Estado = "São Paulo"
                }
            );
          
        }
    }
    
}
