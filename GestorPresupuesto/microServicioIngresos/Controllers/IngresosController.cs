using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Model;
using MongoDB.Driver;

namespace microServicioIngresos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngresosController : ControllerBase
    {
        private readonly MongoDBContext _context;

        public IngresosController(MongoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Modelo>> Get()
        {
            return await _context.Ingresos.Find(_ => true).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Modelo>> Get(string id)
        {
            var ingreso =
                await _context
                    .Ingresos
                    .Find(p => p.Id == id)
                    .FirstOrDefaultAsync();

            if (ingreso == null)
            {
                return NotFound();
            }

            return ingreso;
        }

        [HttpPost]
        public async Task<ActionResult<Modelo>> Create(Modelo ingreso)
        {
            await _context.Ingresos.InsertOneAsync(ingreso);
            return CreatedAtRoute(new { id = ingreso.Id }, ingreso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Modelo ingresoIn)
        {
            var ingreso =
                await _context
                    .Ingresos
                    .Find(p => p.Id == id)
                    .FirstOrDefaultAsync();

            if (ingreso == null)
            {
                return NotFound();
            }

            await _context.Ingresos.ReplaceOneAsync(p => p.Id == id, ingresoIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var ingreso =
                await _context
                    .Ingresos
                    .Find(p => p.Id == id)
                    .FirstOrDefaultAsync();

            if (ingreso == null)
            {
                return NotFound();
            }

            await _context.Ingresos.DeleteOneAsync(p => p.Id == id);

            return NoContent();
        }
    }
}
