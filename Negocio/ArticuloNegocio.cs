using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulos> listar()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select A.Id, A.Codigo, A.Nombre,A.Descripcion, A.Precio, C.Descripcion as Tipo, M.Descripcion as Marca from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdCategoria=C.Id and A.IdMarca=M.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.ID = (int)datos.Lector["ID"];
                    aux.Codigo = (string)datos.leerColumna("Codigo");
                    aux.Nombre = (string)datos.leerColumna("Nombre");
                    aux.Decripcion = (string)datos.leerColumna("Descripcion");

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    else
                        aux.Precio = 0;

                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.leerColumna("Marca");


                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.leerColumna("Tipo");


                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Imagen> listarImagenes(int idArticulo)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = " + idArticulo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void agregar(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into ARTICULOS(Codigo, Nombre, Descripcion, Precio,IdMarca,IdCategoria) values('" + nuevo.Codigo + "','" + nuevo.Nombre + "','" + nuevo.Decripcion + "'," + nuevo.Precio + ",@idMarca,@idCategoria)");

                datos.setearParametro("@idMarca", nuevo.Marca.ID);
                datos.setearParametro("@idCategoria", nuevo.Categoria.ID);

                datos.ejecutarAccion();
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
    }
}
