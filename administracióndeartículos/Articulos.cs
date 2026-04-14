using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administracióndeartículos
{
    internal class Articulos
    {
     public int ID { get; set; }

     public string Codigo { get; set;}

     public string Nombre { get; set; }

     public string Decripcion { get; set; } 
     
     public Marcas IdMarca { get; set; } 
     
     public Categorias Idcategoria  { get; set; } 

     public decimal Precio { get; set; }

     public string ImagenUrl { get; set; }





    }
}
