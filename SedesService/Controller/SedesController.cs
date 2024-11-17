using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SedesService.Model;
using SedesService.Service;

namespace SedesService.Controller;

[ApiController]
[Route("/sedes")]
public class SedesController : ControllerBase
{
    private readonly SedesServiceImp _sedeService;

    public SedesController(SedesServiceImp sedeService)
    {
        _sedeService = sedeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSedes()
    {
        var sedes = await _sedeService.GetSedesAsync();
        return Ok(sedes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSedeById(string id)
    {
        var sede = await _sedeService.GetSedeByIdAsync(id);
        if (sede is null) return NotFound();
        return Ok(sede);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> CreateSede([FromBody] Sede sede)
    {
        await _sedeService.CreateSedeAsync(sede);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> UpdateSede(string id, [FromBody] Sede sede)
    {
        await _sedeService.UpdateSedeAsync(id, sede);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> DeleteSede(string id)
    {
        await _sedeService.DeleteSedeAsync(id);
        return Ok();
    }
}