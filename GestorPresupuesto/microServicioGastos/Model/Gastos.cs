namespace microServicioGastos.Model
{
    public class Gastos
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        
        public string Descripcion { get; set; }
        public int Monto { get; set;}


        public Gastos(int id, DateTime fecha, string tipo, string descripcion, int monto)
        {
            Id = id;
            Fecha = fecha;
            Tipo = tipo;
            Descripcion = descripcion;
            Monto = monto;
        }

        public Gastos()
        {
        }

        public override string ToString()
        {
            return $"{Id} {Fecha} {Tipo} {Descripcion} {Monto}";
        }
    }
}
