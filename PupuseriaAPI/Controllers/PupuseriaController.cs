using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PupuseriaAPI.Models;
using PupuseriaAPI.Services.Iterfaces;

namespace PupuseriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PupuseriaController : ControllerBase
    {
        private readonly IPupuseriaService _PupuseriaService;

        public PupuseriaController(IPupuseriaService pupuseriaService)
        {
            _PupuseriaService = pupuseriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pupuseria>>> GetPupuserias()
        {
            var Pupuseria = await _PupuseriaService.GetPupuserias();
            return Ok(Pupuseria);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPupuseria(int id)
        {
            var Pupuseria = await _PupuseriaService.GetPupuseriaById(id);
            if(Pupuseria == null){
            return NotFound();
            }
            return Ok(Pupuseria);
        }

        [HttpPost]
        public async Task<ActionResult<Pupuseria>> CreatePupuseria(Pupuseria pupuseria)
        {
            var PupuseriaCreado = await _PupuseriaService.CreatePupuseria(pupuseria);
            return CreatedAtAction(nameof(GetPupuseria), new {id = PupuseriaCreado.Id},PupuseriaCreado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePupuseria(int id, Pupuseria pupuseria)
        {
            await _PupuseriaService.UpdatePupuseria(pupuseria, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePupuseria(int id)
        {
            await _PupuseriaService.DeletePupuseria(id);
            return NoContent();
        }
    }
}
