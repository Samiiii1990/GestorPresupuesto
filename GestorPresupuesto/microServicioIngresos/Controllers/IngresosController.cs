using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace microServicioIngresos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        // GET: api/<ModeloController>
        [HttpGet]
        public async Task<List<Modelo>> Get()
        {
            List<Modelo> ingresos =
                new List<Modelo> {
                    new Modelo {
                        Id = 1,
                        Fecha = new DateTime(2023, 11, 2),
                        Tipo = "Venta",
                        Monto = 1000,
                        Descripcion = "Venta 1"
                    },
                    new Modelo {
                        Id = 2,
                        Fecha = new DateTime(2023, 11, 4),
                        Tipo = "Venta",
                        Monto = 1000,
                        Descripcion = "Venta 2"
                    },
                    new Modelo {
                        Id = 3,
                        Fecha = new DateTime(2023, 11, 7),
                        Tipo = "Venta",
                        Monto = 1000,
                        Descripcion = "Venta 3"
                    },
                    new Modelo {
                        Id = 4,
                        Fecha = new DateTime(2023, 11, 9),
                        Tipo = "Venta",
                        Monto = 1000,
                        Descripcion = "Venta 4"
                    },
                    new Modelo {
                        Id = 5,
                        Fecha = new DateTime(2023, 11, 22),
                        Tipo = "Venta",
                        Monto = 000,
                        Descripcion = "Venta 5"
                    }
                };

            return ingresos;
        }
    }
}
