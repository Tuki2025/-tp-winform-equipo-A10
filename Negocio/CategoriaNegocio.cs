using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar() {
            
            
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("select Id, Descripcion from CATEGORIAS \r\n");
                datos.ejecutarLectura();
                while (datos.Lector.Read()) {

                    Categoria aux = new Categoria();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);

                }
                return lista;

            }         
            catch(Exception ex) {

                throw ex;         
            }
            finally
            {
                datos.cerraConexion();
            }
        }
        public void agregar(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into CATEGORIAS (Descripcion) values (@desc)");
                datos.setearParametro("@desc", nuevo.Descripcion);
                datos.ejecutarAccion();
            }
            finally { datos.cerraConexion(); }
        }

        public void modificar(Categoria cat)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update CATEGORIAS set Descripcion = @desc where Id = @id");
                datos.setearParametro("@desc", cat.Descripcion);
                datos.setearParametro("@id", cat.ID);
                datos.ejecutarAccion();
            }
            finally { datos.cerraConexion(); }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from CATEGORIAS where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            finally { datos.cerraConexion(); }
        }


    }
}
