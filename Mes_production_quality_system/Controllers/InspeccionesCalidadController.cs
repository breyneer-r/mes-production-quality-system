using Mes_production_quality_system.Models;
using Mes_production_quality_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mes_production_quality_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InspeccionesCalidadController : ControllerBase
{
    private readonly IInspeccionCalidadService _service;

    public InspeccionesCalidadController(IInspeccionCalidadService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(InspeccionesCalidad entity)
    {
        var creado = await _service.CreateAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = creado.IdInspeccion }, creado);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, InspeccionesCalidad entity)
    {
        entity.IdInspeccion = id;
        return await _service.UpdateAsync(entity) ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => await _service.DeleteAsync(id) ? NoContent() : NotFound();
}
