using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Model;
using MongoDB.Driver;
using microServicioIngresos.Services;

namespace microServicioIngresos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngresosController : ControllerBase
    {
     private readonly IngresosServices _ingresoService;

     public IngresosController(IngresosServices ingresoService) =>
        _ingresoService = ingresoService;

    [HttpGet]
    public async Task<List<Modelo>> Get() =>
        await _ingresoService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Modelo>> Get(string id)
    {
        var ingreso = await _ingresoService.GetAsync(id);

        if (ingreso is null)
        {
            return NotFound();
        }

        return ingreso;
    }

    [HttpPost]
     public async Task<ActionResult<Modelo>> Post([FromBody ] Modelo newIngreso)
    {
    try
    {
        newIngreso.Id = null;

        await _ingresoService.CreateAsync(newIngreso);

        return CreatedAtAction(nameof(Get), new { id = newIngreso.Id }, newIngreso);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        return BadRequest(); 
    }

    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Modelo updatedIngreso)
    {
        var ingreso = await _ingresoService.GetAsync(id);

        if (ingreso is null)
        {
            return NotFound();
        }

        updatedIngreso.Id = ingreso.Id;

        await _ingresoService.UpdateAsync(id, updatedIngreso);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        Console.WriteLine(id);
        var ingreso = await _ingresoService.GetAsync(id);
        Console.WriteLine(ingreso);
        if (ingreso is null)
        {
            return NotFound();
        }

        await _ingresoService.RemoveAsync(id);

        return NoContent();
    }
    }
}