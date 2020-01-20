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
            throw new System.NotImplementedException();
        }

        public Task<Result> Handle(AtualizarUsuarioCmd request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> Handle(ApagarUsuarioCmd request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
