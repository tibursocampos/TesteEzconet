using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteEzconet.Domain.Models;
using TesteEzconet.Persistence;

namespace TesteEzconet.Controllers
{
    [Route("api/TesteEzconet/Usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly TesteEzconetContext _context;

        public UsuariosController(TesteEzconetContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioPorId(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound(new { mensagem = "Usuário não encontrado !!!" });
            }

            return usuario;
        }

        [HttpGet("busca")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarioNome(string nome)
        {
            IQueryable<Usuario> consulta = _context.Usuarios;

            if (!string.IsNullOrEmpty(nome))
            {
                consulta = consulta.Where(e => e.Nome.Contains(nome));
            }

            if (consulta == null)
            {
                return NotFound(new { mensagem = "Usuário não encontrado !!!" });
            }

            return await consulta.ToListAsync();
        }

        [HttpGet("ativo")]
        public ActionResult<IEnumerable<Usuario>> GetUsuarioAtivo()
        {
            var usuario = _context.Usuarios.Where(x => x.Ativo == true).ToList();


            if (usuario == null)
            {
                return NotFound(new { mensagem = "Usuário não encontrado !!!" });
            }

            return usuario;
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest(new { mensagem = "Usuário não encontrado !!!" });
            }

            _context.Entry(usuario).State = EntityState.Modified;

            int tamanhoNome = usuario.Nome.Length;
            if (tamanhoNome < 3 || tamanhoNome > 200)
            {
                return BadRequest(new { mensagem = "Campo nome deve ter entre 3 e 200 caracteres !!!" });
            }

            if (usuario.Nome == null || usuario.Email == null || usuario.DataNascimento == null ||
                usuario.Nome == "" || usuario.Email == "")
            {
                return BadRequest(new { mensagem = "Campos obrigatórios não preenchidos !!!" });
            }

            try
            {
                await _context.SaveChangesAsync();                

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound(new { mensagem = "Usuário não encontrado !!!" });
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { mensagem = "Usuário alterado com sucesso !!!" });
        }

        [HttpPut("{id}/ativar")]
        public async Task<IActionResult> PutUsuarioAtivarDesativar(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest(new { mensagem = "Usuário não encontrado !!!" });
            }

            var estadoAtual = usuario.Ativo;
            if (estadoAtual)
            {
                estadoAtual = false;
            } else
            {
                estadoAtual = true;
            }
            usuario.Ativo = estadoAtual;

            int tamanhoNome = usuario.Nome.Length;
            if (tamanhoNome < 3 || tamanhoNome > 200)
            {
                return BadRequest(new { mensagem = "Campo nome deve ter entre 3 e 200 caracteres !!!" });
            }

            if (usuario.Nome == null || usuario.Email == null || usuario.DataNascimento == null ||
                usuario.Nome == "" || usuario.Email == "")
            {
                return BadRequest(new { mensagem = "Campos obrigatórios não preenchidos !!!" });
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound(new { mensagem = "Usuário não encontrado !!!" });
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { mensagem = "Usuário alterado com sucesso !!!" });
        }
                
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        { 
            {
                _context.Usuarios.Add(usuario);

                int tamanhoNome = usuario.Nome.Length;
                if (tamanhoNome < 3 || tamanhoNome > 200)
                {
                    return BadRequest();
                }

                if (usuario.Nome == null || usuario.Email == null || usuario.DataNascimento == null ||
                    usuario.Nome == "" || usuario.Email == "")
                {
                    return BadRequest(new { mensagem = "Usuário não encontrado !!!" });
                }

                await _context.SaveChangesAsync(); 
            }


            return Ok(new { mensagem = "Usuário alterado com sucesso !!!" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound(new { mensagem = "Usuário não encontrado !!!" });
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioId == id);
        }
    }
}
