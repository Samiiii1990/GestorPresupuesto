﻿using Microsoft.AspNetCore.Mvc;
using microServicioIngresos.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace microServicioIngresos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        // GET: api/<IngresosController>
        [HttpGet]
    public async Task<List<Ingresos>> Get()
    {

        List<Ingresos> ingresos = new List<Ingresos>
        {
            new Ingresos { Id = 1, Fecha = DateTime.Now, Tipo = "Venta", Monto = -1000, Descripcion = "Venta 1" },
            new Ingresos { Id = 2, Fecha = DateTime.Now, Tipo = "Venta", Monto = -1000, Descripcion = "Venta 2" },
            new Ingresos { Id = 3, Fecha = DateTime.Now, Tipo = "Venta", Monto = -1000, Descripcion = "Venta 3" },
            new Ingresos { Id = 4, Fecha = DateTime.Now, Tipo = "Venta", Monto = -1000, Descripcion = "Venta 4" },
            new Ingresos { Id = 5, Fecha = DateTime.Now, Tipo = "Venta", Monto = -1000, Descripcion = "Venta 5" }
        };

        return ingresos;
    }
}
}   