using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Usuario.Domain.Command;
using Usuario.Domain.Interfaces.Repository;

namespace Usuario.Domain.Services
{
    public class UsuarioService : IRequestHandler<InserirUsuarioCmd, Result>,
                        IRequestHandler<AtualizarUsuarioCmd, Result>,
                        IRequestHandler<ApagarUsuarioCmd, Result>
    {

        private readonly IUsuarioRepository usuarioRepository;
        

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }




        public Task<Result> Handle(InserirUsuarioCmd request, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (request.IsValid())
            {
                var qUsuario = usuarioRepository.Get(c=>c.Email==request.Email);
                if (qUsuario == null)
                {
                    Usuario.Domain.Entities.Usuario usuario = new Usuario.Domain.Entities.Usuario();
                    usuario.SetUsuario(Guid.NewGuid(), request.Nome, request.Email, request.Cpf,
                        request.DataNascimento, request.Cidade, request.Estado);
                    usuarioRepository.Add(usuario);

                    result.message = "Usuário criado com sucesso";
                }
                else
                {
                    var message = "O Usuario não existe";
                    result.AddError(message);
                }
            }
            else
            {
                result.AddErrors(GetErrors(request).ToList());
            }

            return Task.FromResult<Result>(result);
        }

        public Task<Result> Handle(AtualizarUsuarioCmd request, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (request.IsValid())
            {
                var qUsuario = usuarioRepository.GetById(request.Id);
                if (qUsuario != null)
                {
                    
                    qUsuario.SetUsuario(request.Id, request.Nome, request.Email, request.Cpf,
                        request.DataNascimento, request.Cidade, request.Estado);

                    usuarioRepository.Update(qUsuario);

                    result.message = "Usuário alterado com sucesso";
                }
                else
                {
                    var message = "O Usuario não existe";
                    result.AddError(message);
                }
            }
            else
            {
                result.AddErrors(GetErrors(request).ToList());
            }

            return Task.FromResult<Result>(result);
        }

        public Task<Result> Handle(ApagarUsuarioCmd request, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (request.Id != Guid.Empty)
            {
                var qUsuario = usuarioRepository.GetById(request.Id);
                if (qUsuario != null)
                {
                    usuarioRepository.Remove(qUsuario);

                    result.message = "Usuário apagado com sucesso";
                }
                else
                {
                    var message = "O Usuario não existe";
                    result.AddError(message);
                }
            }


            return Task.FromResult<Result>(result);
        }

        private IEnumerable<string> GetErrors(UsuarioCmd request) =>
            request.ValidationResult.Errors.Select(err => err.ErrorMessage);

    }
}
