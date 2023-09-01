using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace TA33_1_sgallego.Models
{
    public class Almacen
    {
        public int Codigo {  get; set; }

        public String Lugar { get; set; }

        public int Capacidad { get; set; }
        public ICollection<Caja> Caja { get; set; } = new List<Caja>();

    }

    public class Caja
    {
        public int NumReferncia { get; set; }
        
        public String Contenido{ get; set;}
        public int Valor { get; set;}

        public int AlmacenCodigo { get; set; }
        public Almacen Almacen { get; set; }
    }
}
