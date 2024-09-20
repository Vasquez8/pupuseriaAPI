using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PupuseriaAPI.Models;
using PupuseriaAPI.Services.Iterfaces;

namespace PupuseriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotoController : ControllerBase
    {
        private readonly IVotoService _votoService;
        public VotoController(IVotoService votoService){
            _votoService = votoService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voto>>> GetVotos(){
            var votos = await _votoService.GetVotos();
            return Ok(votos);
        }

        [HttpGet("pupuseria/{idPupuseria}")]
        public async Task<ActionResult<IEnumerable<Voto>>> GetVotosByPupuseria(int idPupuseria){
            var votos = await _votoService.GetVotosByIdPupuseria(idPupuseria);
            return Ok(votos);
        }

        [HttpPost("pupuseria/{idPupuseria}")]
        public async Task<ActionResult> Votar(int idPupuseria, int idUsuario){
            await _votoService.VotarAsync(idPupuseria, idUsuario);
            return NoContent();
        }

    }
}
