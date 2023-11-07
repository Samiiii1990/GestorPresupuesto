﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using microServicioGastos.Model;
using microServicioIngresos.Model;
using microServicioReporte.Model;
using System.Text;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace microServicioReporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {

        
        private List<Gastos> _gastos = new List<Gastos>();

        private List<Ingresos> _ingresos = new List<Ingresos>();

        private String currentCount;

        [HttpGet]
        public async Task GetGasto()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var resultGastos =
                        await client
                            .GetAsync("http://host.docker.internal:4000/api/Gastos/");
                    if (resultGastos.IsSuccessStatusCode)
                    {
                        var resultadoServicioGastos =
                            await resultGastos.Content.ReadAsStringAsync();
                        var res1 =
                            JsonSerializer
                                .Deserialize
                                <List<Gastos>>(resultadoServicioGastos,
                                new JsonSerializerOptions()
                                { PropertyNameCaseInsensitive = true });

                        _gastos = res1;

                    }

                    var resultIngresos =
                        await client
                            .GetAsync("http://host.docker.internal:5000/api/Ingresos/");
                    if (resultIngresos.IsSuccessStatusCode)
                    {
                        var resultadoServicioIngresos =
                            await resultIngresos.Content.ReadAsStringAsync();
                        var res2 =
                            JsonSerializer
                                .Deserialize
                                <List<Ingresos>>(resultadoServicioIngresos,
                                new JsonSerializerOptions()
                                { PropertyNameCaseInsensitive = true });

                        _ingresos = res2;

                    }
                }
                catch (Exception ex)
                {
                    currentCount = ex.Message;
                }
            }
        }

        public async Task<List<Reporte>> Get()
        {
            var reporte =
                (
                from gasto in _gastos
                join ingreso in _ingresos on gasto.Id equals ingreso.Id
                select
                new Reporte {
                    Id = gasto.Id,
                    Fecha = gasto.Fecha,
                    TipoIngreso = ingreso.Tipo,
                    MontoIngreso = ingreso.Monto,
                    DescripcionIngreso = ingreso.Descripcion,
                    TipoGasto = gasto.Tipo,
                    MontoGasto = gasto.Monto,
                    DescripcionGasto = gasto.Descripcion,
                    Diferencia = ingreso.Monto - gasto.Monto
                }
                ).ToList();

            return reporte;
        }
    }
}
