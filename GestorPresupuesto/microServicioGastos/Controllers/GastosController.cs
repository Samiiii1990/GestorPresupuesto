using Microsoft.AspNetCore.Mvc;
using Model;

namespace microServicioGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        // GET: api/<ModeloController>
        [HttpGet]
        public async Task<List<Modelo>> Get()
        {
            List<Modelo> gastos =
                new List<Modelo> {
                    new Modelo {
                        Id = 1,
                        Fecha = new DateTime(2023, 11, 11),
                        Tipo = "Gasto",
                        Monto = 20000,
                        Descripcion = "Comida en restaurante"
                    },
                    new Modelo {
                        Id = 2,
                        Fecha = new DateTime(2023, 11, 19),
                        Tipo = "Gasto",
                        Monto = 10000,
                        Descripcion = "Combustible para el auto"
                    },
                    new Modelo {
                        Id = 3,
                        Fecha = new DateTime(2023, 11, 12),
                        Tipo = "Gasto",
                        Monto = 5000,
                        Descripcion = "Entradas de cine"
                    },
                    new Modelo {
                        Id = 4,
                        Fecha = new DateTime(2023, 11, 5),
                        Tipo = "Gasto",
                        Monto = 35000,
                        Descripcion = "Ropa y accesorios"
                    },
                    new Modelo {
                        Id = 5,
                        Fecha = new DateTime(2023, 11, 30),
                        Tipo = "Gasto",
                        Monto = 50000,
                        Descripcion = "Pago de servicios"
                    }
                };
            return gastos;
        }
    }
}
