using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
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
                        Tipo = "Compra",
                        Monto = 1000,
                        Descripcion = "Gasto 1"
                    },
                    new Modelo {
                        Id = 2,
                        Fecha = new DateTime(2023, 11, 19),
                        Tipo = "Compra",
                        Monto = 3000,
                        Descripcion = "Gasto 2"
                    },
                    new Modelo {
                        Id = 3,
                        Fecha = new DateTime(2023, 11, 12),
                        Tipo = "Compra",
                        Monto = 5000,
                        Descripcion = "Gasto 3"
                    },
                    new Modelo {
                        Id = 4,
                        Fecha = new DateTime(2023, 11, 5),
                        Tipo = "Compra",
                        Monto = 7000,
                        Descripcion = "Gasto 4"
                    },
                    new Modelo {
                        Id = 5,
                        Fecha = new DateTime(2023, 11, 30),
                        Tipo = "Compra",
                        Monto = 9000,
                        Descripcion = "Gasto 5"
                    }
                };

            return gastos;
        }
    }
}
