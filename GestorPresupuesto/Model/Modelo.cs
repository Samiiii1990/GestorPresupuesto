using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
 
     public class Modelo
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        
        public string Descripcion { get; set; }
        public int Monto { get; set;}


        public Modelo(int id, DateTime fecha, string tipo, string descripcion, int monto)
        {
            Id = id;
            Fecha = fecha;
            Tipo = tipo;
            Descripcion = descripcion;
            Monto = monto;
        }

        public Modelo()
        {
        }

        public override string ToString()
        {
            return $"{Id} {Fecha} {Tipo} {Descripcion} {Monto}";
        }
    }
}

