using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Model
{
    public class Modelo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("fecha")]
        public DateTime Fecha { get; set; }

        [BsonElement("tipo")]
        public string Tipo { get; set; }

        [BsonElement("description")]
        public string Descripcion { get; set; }

        [BsonElement("monto")]
        public int Monto { get; set; }

        public Modelo(
            string id,
            DateTime fecha,
            string tipo,
            string descripcion,
            int monto
        )
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
