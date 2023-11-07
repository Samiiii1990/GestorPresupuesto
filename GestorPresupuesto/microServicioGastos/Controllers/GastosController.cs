using Microsoft.AspNetCore.Mvc;
using microServicioGastos.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace microServicioGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        // GET: api/<GastosController>
        [HttpGet]
    public async Task<List<Gastos>> Get()
    {

        List<Gastos> gastos = new List<Gastos>
        {
            new Gastos { Id = 1, Fecha = DateTime.Now, Tipo = "Compra", Monto = 1000, Descripcion = "Gasto 1" },
            new Gastos { Id = 2, Fecha = DateTime.Now, Tipo = "Compra", Monto = 3000, Descripcion = "Gasto 2" },
            new Gastos { Id = 3, Fecha = DateTime.Now, Tipo = "Compra", Monto = 5000, Descripcion = "Gasto 3" },
            new Gastos { Id = 4, Fecha = DateTime.Now, Tipo = "Compra", Monto = 7000, Descripcion = "Gasto 4" },
            new Gastos { Id = 5, Fecha = DateTime.Now, Tipo = "Compra", Monto = 9000, Descripcion = "Gasto 5" }
        };

        return gastos;
    }
       
    }
}
