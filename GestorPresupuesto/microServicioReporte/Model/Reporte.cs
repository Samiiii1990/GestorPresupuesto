namespace Reporte
{
    public class ReporteModel
    {
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string TipoGasto { get; set; }
    public decimal MontoGasto { get; set; }
    public string DescripcionGasto { get; set; }
    public string TipoIngreso { get; set; }
    public decimal MontoIngreso { get; set; }
    public string DescripcionIngreso { get; set; }
    public decimal Diferencia { get; set; }

        public ReporteModel(int id, DateTime fecha, string tipoGasto, decimal montoGasto, string descripcionGasto, string tipoIngreso, decimal montoIngreso, string descripcionIngreso, decimal diferencia)
        {
            Id = id;
            Fecha = fecha;
            TipoGasto = tipoGasto;
            MontoGasto = montoGasto;
            DescripcionGasto = descripcionGasto;
            TipoIngreso = tipoIngreso;
            MontoIngreso = montoIngreso;
            DescripcionIngreso = descripcionIngreso;
            Diferencia = diferencia;
        }

        public ReporteModel()
        {
        }

        public override string ToString()
        {
            return $"{Id} {Fecha} {TipoGasto} {MontoGasto} {DescripcionGasto} {TipoIngreso} {MontoIngreso} {DescripcionIngreso} {Diferencia}";
        }
    }
}
