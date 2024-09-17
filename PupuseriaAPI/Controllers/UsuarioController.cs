using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PupuseriaAPI.Models;
using PupuseriaAPI.Services.Iterfaces;

namespace PupuseriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuario = await _usuarioService.GetUsuarios();
            return Ok(usuario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuarioById(id);
            if(usuario == null){
            return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            var usuarioCreado = await _usuarioService.CreateUsuario(usuario);
            return CreatedAtAction(nameof(GetUsuario), new {id = usuarioCreado.Id},usuarioCreado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuario usuario)
        {
            await _usuarioService.UpdateUsuario(usuario, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _usuarioService.DeleteUsuario(id);
            return NoContent();
        }
    }
}
