using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio

{
    public class Articulos
    {
        public int ID { get; set; }

        public string Codigo { get; set;}

        public string Nombre { get; set; }

        public string Descripcion { get; set; } 
     
        public Marca Marca { get; set; } 
     
        public Categoria Categoria  { get; set; } 

        public decimal Precio { get; set; }

        public List<Imagen> Imagenes { get; set; }

        public Articulos()
        {
            //Cada vez que se cree un objeto Articulos, ya va a tener su lista de imagenes para ser usada
            Imagenes = new List<Imagen>();
        }

    }
}
