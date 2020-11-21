using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEzconet.Domain;
using TesteEzconet.Domain.Models;
using TesteEzconet.Service.DTO;

namespace TesteEzconet.Service
{
    public interface IUsuarioService
    {
        Usuario[] SelectUsuario();
        Usuario[] SelectUsuarioId(int id);
        Task AddUsuario<UsuarioDTO>(UsuarioDTO dto);
        void Remove<UsuarioDTO>(UsuarioDTO dto);
    }
    /* public class UsuarioService : IUsuarioService
    {
        private readonly IRepository repository;

        public UsuarioService(IRepository repository)
        {
            this.repository = repository;
        }

        public Usuario[] SelectUsuario()
        {
            var usuarios = repository.Query<Usuario>();
            return usuarios.ToArray();
        }

        public Usuario SelectUsuarioId(int id)
        {
            var usuario = repository.Query<Usuario>().Where(x => x.UsuarioId == id);
            return usuario.To;
        }


        public async Task AddUsuario<UsuarioDTO>(UsuarioDTO dto)
        {

        }

        public void Remove<UsuarioDTO>(UsuarioDTO dto)
        {

        }


    }*/
}
