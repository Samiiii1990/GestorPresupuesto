using Microsoft.AspNetCore.Mvc;
using Ingresos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace microServicioIngresos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        // GET: api/<IngresosModelController>
        [HttpGet]
    public async Task<List<IngresosModel>> Get()
    {

        List<IngresosModel> ingresos = new List<IngresosModel>
        {
            new IngresosModel { Id = 1, Fecha = DateTime.Now, Tipo = "Venta", Monto = -1000, Descripcion = "Venta 1" },
            new IngresosModel { Id = 2, Fecha = DateTime.Now, Tipo = "Venta", Monto = -1000, Descripcion = "Venta 2" },
            new IngresosModel { Id = 3, Fecha = DateTime.Now, Tipo = "Venta", Monto = -1000, Descripcion = "Venta 3" },
            new IngresosModel { Id = 4, Fecha = DateTime.Now, Tipo = "Venta", Monto = -1000, Descripcion = "Venta 4" },
            new IngresosModel { Id = 5, Fecha = DateTime.Now, Tipo = "Venta", Monto = -1000, Descripcion = "Venta 5" }
        };

        return ingresos;
    }
}
}   