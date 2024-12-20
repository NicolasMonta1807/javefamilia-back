using EspacioService.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EspacioService.Controller;

[ApiController]
[Route("/espacio")]
public class EspacioController : ControllerBase
{
    private readonly Service.EspacioService _espacioService;

    public EspacioController(Service.EspacioService espacioService)
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
    [Authorize(Roles = "Operario,Administrador")]
    public async Task<IActionResult> CreateEspacio([FromBody] Espacio espacio)
    {
        await _espacioService.CreateEspacioAsync(espacio);
        return Ok();
    }

    [HttpPost("/addHorario/{id}")]
    [Authorize(Roles = "Operario,Administrador")]
    public async Task<IActionResult> AddHorario(string id, [FromBody] HorarioEspacio horario)
    {
        await _espacioService.AddHorarioAsync(id, horario);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Operario,Administrador")]
    public async Task<IActionResult> UpdateEspacio(string id, [FromBody] Espacio espacio)
    {
        await _espacioService.UpdateEspacioAsync(id, espacio);
        return Ok();
    }

    [HttpPut("/updateHorario/{id}/{idHorario}")]
    [Authorize(Roles = "Operario,Administrador")]
    public async Task<IActionResult> UpdateHorario(string id, string idHorario, [FromBody] HorarioEspacio horario)
    {
        await _espacioService.UpdateHorarioAsync(id, idHorario, horario);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Operario,Administrador")]
    public async Task<IActionResult> DeleteEspacio(string id)
    {
        await _espacioService.DeleteEspacioAsync(id);
        return Ok();
    }

    [HttpDelete("/deleteHorario/{id}/{idHorario}")]
    [Authorize(Roles = "Operario,Administrador")]
    public async Task<IActionResult> DeleteHorario(string id, string idHorario)
    {
        await _espacioService.DeleteHorarioAsync(id, idHorario);
        return Ok();
    }
}