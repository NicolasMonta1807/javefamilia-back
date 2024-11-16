using EspacioService.Model;
using EspacioService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace EspacioService.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class EspacioController : ControllerBase
    {
        private readonly EspacioServiceImp _espacioService;

        public EspacioController(EspacioServiceImp espacioService)
        {
            _espacioService = espacioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEspacios()
        {
            var espacios = await _espacioService.GetEspaciosAsync();
            return Ok(espacios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEspacioById(string id)
        {
            var espacio = await _espacioService.GetEspacioByIdAsync(id);
            if (espacio is null) return NotFound();
            return Ok(espacio);
        }

        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> CreateEspacio([FromBody] Espacio espacio)
        {
            await _espacioService.CreateEspacioAsync(espacio);
            return Ok();
        }
        [HttpPost("/addHorario/{id}")]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> AddHorario(string id, [FromBody] HorarioEspacio horario)
        {
            await _espacioService.AddHorarioAsync(id, horario);
            return Ok();
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> UpdateEspacio(string id, [FromBody] Espacio espacio)
        {
            await _espacioService.UpdateEspacioAsync(id, espacio);
            return Ok();
        }
        [HttpPut("/updateHorario/{id}/{idHorario}")]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> UpdateHorario(string id, string idHorario, [FromBody] HorarioEspacio horario)
        {
            await _espacioService.UpdateHorarioAsync(id, idHorario, horario);
            return Ok();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteEspacio(string id)
        {
            await _espacioService.DeleteEspacioAsync(id);
            return Ok();
        }

        [HttpDelete("/deleteHorario/{id}/{idHorario}")]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteHorario(string id, string idHorario)
        {
            await _espacioService.DeleteHorarioAsync(id, idHorario);
            return Ok();
        }
    }
}