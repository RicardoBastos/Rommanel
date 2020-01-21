using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usuario.Domain;
using Usuario.Domain.Command;
using Usuario.Domain.Interfaces.Repository;

namespace Usuario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IMediator mediator;
        private readonly IUsuarioRepository usuarioRepository;


        public UsuariosController(IMediator mediator, IUsuarioRepository usuarioRepository)
        {
            this.mediator = mediator;
            this.usuarioRepository = usuarioRepository;
        }


        [HttpGet("{id}")]
        public Usuario.Domain.Entities.Usuario GetById(Guid id)
        {
            return usuarioRepository.GetById(id);
        }


        [HttpGet]
        public IEnumerable<Usuario.Domain.Entities.Usuario> GetAll()
        {
            return usuarioRepository.GetAll();
        }


        [HttpPost]
        public async Task<Result> Post([FromBody]InserirUsuarioCmd usuario)
        {
            var result = await mediator.Send<Result>(usuario);
            return result;
        }


        [HttpPut("{Id}")]
        public async Task<Result> Put(Guid Id, [FromBody]AtualizarUsuarioCmd usuario)
        {
            usuario.SetId(Id);
            var result = await mediator.Send<Result>(usuario);
            return result;
        }


        [HttpDelete("{Id}")]
        public async Task<Result> Delete(Guid Id)
        {
            var result = await mediator.Send<Result>(new ApagarUsuarioCmd(Id));
            return result;
            
        }

    }
}
