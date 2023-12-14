using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Model;
using MongoDB.Driver;
using microServicioGastos.Services;

namespace microServicioGastos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GastosController : ControllerBase
    {
     private readonly GastosServices _gastoService;

     public GastosController(GastosServices gastoService) =>
        _gastoService = gastoService;

    [HttpGet]
    public async Task<List<Modelo>> Get() =>
        await _gastoService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Modelo>> Get(string id)
    {
        var gasto = await _gastoService.GetAsync(id);

        if (gasto is null)
        {
            return NotFound();
        }

        return gasto;
    }

    [HttpPost]
    public async Task<ActionResult<Modelo>> Post([FromBody] Modelo newGasto)
    {
    try
    {
        Console.WriteLine(newGasto);
        // Allow MongoDB to generate the Id
        newGasto.Id = null;

        await _gastoService.CreateAsync(newGasto);

        return CreatedAtAction(nameof(Get), new { id = newGasto.Id }, newGasto);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        return BadRequest(); // or return an appropriate error response
    }
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Modelo updatedGasto)
    {
        var gasto = await _gastoService.GetAsync(id);

        if (gasto is null)
        {
            return NotFound();
        }

        updatedGasto.Id = gasto.Id;

        await _gastoService.UpdateAsync(id, updatedGasto);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        Console.WriteLine(id);
        var gasto = await _gastoService.GetAsync(id);
        Console.WriteLine(gasto);
        if (gasto is null)
        {
            return NotFound();
        }

        await _gastoService.RemoveAsync(id);

        return NoContent();
    }
    }
}