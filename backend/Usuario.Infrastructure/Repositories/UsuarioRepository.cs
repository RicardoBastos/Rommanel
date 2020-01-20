using Usuario.Domain.Interfaces.Repository;

namespace Usuario.Infrastructure.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario.Domain.Entities.Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(UsuarioContext context) : base(context) { }
    }
}
