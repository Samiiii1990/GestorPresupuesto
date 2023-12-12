using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Model;
using MongoDB.Driver;

namespace microServicioGastos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GastosController : ControllerBase
    {
        private readonly MongoDBContext _context;

        public GastosController(MongoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Modelo>> Get()
        {
            return await _context.Gastos.Find(_ => true).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Modelo>> Get(string id)
        {
            var gasto =
                await _context
                    .Gastos
                    .Find(p => p.Id == id)
                    .FirstOrDefaultAsync();

            if (gasto == null)
            {
                return NotFound();
            }

            return gasto;
        }

        [HttpPost]
        public async Task<ActionResult<Modelo>> Create(Modelo gasto)
        {
            await _context.Gastos.InsertOneAsync(gasto);
            return CreatedAtRoute(new { id = gasto.Id }, gasto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Modelo gastoIn)
        {
            var gasto =
                await _context
                    .Gastos
                    .Find(p => p.Id == id)
                    .FirstOrDefaultAsync();

            if (gasto == null)
            {
                return NotFound();
            }

            await _context.Gastos.ReplaceOneAsync(p => p.Id == id, gastoIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var gasto =
                await _context
                    .Gastos
                    .Find(p => p.Id == id)
                    .FirstOrDefaultAsync();

            if (gasto == null)
            {
                return NotFound();
            }

            await _context.Gastos.DeleteOneAsync(p => p.Id == id);

            return NoContent();
        }
    }
}
