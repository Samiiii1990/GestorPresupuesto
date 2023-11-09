using Microsoft.AspNetCore.Mvc;
using Model;


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
                        Tipo = "Ingreso",
                        Monto = 100000,
                        Descripcion = "Venta de productos"
                    },
                    new Modelo {
                        Id = 2,
                        Fecha = new DateTime(2023, 11, 4),
                        Tipo = "Ingreso",
                        Monto = 15000,
                        Descripcion = "Venta de servicios"
                    },
                    new Modelo {
                        Id = 3,
                        Fecha = new DateTime(2023, 11, 7),
                        Tipo = "Ingreso",
                        Monto = 20000,
                        Descripcion = "Bonificación"
                    },
                    new Modelo {
                        Id = 4,
                        Fecha = new DateTime(2023, 11, 9),
                        Tipo = "Ingreso",
                        Monto = 120000,
                        Descripcion = "Venta de productos electrónicos"
                    },
                    new Modelo {
                        Id = 5,
                        Fecha = new DateTime(2023, 11, 22),
                        Tipo = "Ingreso",
                        Monto = 80000,
                        Descripcion = "Ingresos por inversiones"
                    }
                };

            return ingresos;
        }
    }
}
