using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace administracióndeartículos
{
    internal class ArticuloNegocio
    {

        public List<Articulos> listar() {

            List<Articulos> lista = new List<Articulos> ();
            SqlConnection Conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                Conexion.ConnectionString = "Server=.\\SQLEXPRESS;database=CATALOGO_P3_DB;integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Id, Codigo, Nombre,Descripcion, Precio from ARTICULOS ";
                comando.Connection = Conexion;
                Conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read()) {
                    Articulos aux = new Articulos();
                    aux.ID = (int)lector["ID"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Decripcion = (string)lector["Descripcion"];
                    aux.Precio = (decimal)lector["Precio"];
                    lista.Add(aux);
                }

                Conexion.Close(); 
                return lista;
            }
            catch (Exception ex) {


                throw ex;
            }





        }
    
    
    
    }
}
