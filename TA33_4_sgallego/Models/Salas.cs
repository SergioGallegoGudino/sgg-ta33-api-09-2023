using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace TA33_1_sgallego.Models
{
    public class Pelicula
    {
        public int Codigo {  get; set; }

        public String Nombre { get; set; }

        public int Edad { get; set; }
        public ICollection<Sala> Sala { get; set; } = new List<Sala>();

    }

    public class Sala
    {
        public int Codigo { get; set; }
        
        public String Nombre{ get; set;}

        public int PeliculaCodigo { get; set; }
        public Pelicula Pelicula{ get; set; }
    }
}
