using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class MarcaNegocio
    {

        public List<Marca> listar()
        {

            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("select Id, Descripcion from MARCAS \r\n");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                datos.cerraConexion();

            }
        }

        public void agregar(Marca nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into MARCAS (Descripcion) values (@desc)");
                datos.setearParametro("@desc", nuevo.Descripcion);
                datos.ejecutarAccion();
            }
            finally { datos.cerraConexion(); }
        }

        public void modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update MARCAS set Descripcion = @desc where Id = @id");
                datos.setearParametro("@desc", marca.Descripcion);
                datos.setearParametro("@id", marca.ID);
                datos.ejecutarAccion();
            }
            finally { datos.cerraConexion(); }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from MARCAS where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            finally { datos.cerraConexion(); }
        }

    }
}
