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
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.IdMarca, A.IdCategoria, C.Descripcion AS Tipo, M.Descripcion AS Marca FROM ARTICULOS A JOIN CATEGORIAS C ON A.IdCategoria = C.Id JOIN MARCAS M ON A.IdMarca = M.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    System.Diagnostics.Debug.WriteLine(datos.Lector[0].ToString());
                    Articulos aux = new Articulos();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.Codigo = (string)datos.leerColumna("Codigo");
                    aux.Nombre = (string)datos.leerColumna("Nombre");
                    aux.Descripcion = (string)datos.leerColumna("Descripcion");

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    else
                        aux.Precio = 0;

                    aux.Marca = new Marca();
                    aux.Marca.ID = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.leerColumna("Marca");


                    aux.Categoria = new Categoria();
                    aux.Categoria.ID = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.leerColumna("Tipo");

                    aux.Imagenes = listarImagenes(aux.ID);

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
                datos.setearConsulta("Insert into ARTICULOS(Codigo, Nombre, Descripcion, Precio,IdMarca,IdCategoria) values('" + nuevo.Codigo + "','" + nuevo.Nombre + "','" + nuevo.Descripcion + "'," + nuevo.Precio + ",@idMarca,@idCategoria)");

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

        public void modificar(Articulos articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, IdMarca = @IdMarca, IdCategoria = @IdCategoria WHERE Id = @Id");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@IdMarca", articulo.Marca.ID);
                datos.setearParametro("@IdCategoria", articulo.Categoria.ID);
                datos.setearParametro("@Id", articulo.ID);
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
        public void eliminar(int ID)
        {
            AccesoDatos datosImagenes = new AccesoDatos();
            AccesoDatos datosArticulos = new AccesoDatos();
            try
            {
                datosImagenes.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @Id");
                datosImagenes.setearParametro("@Id", ID);
                datosImagenes.ejecutarAccion();
                
                datosArticulos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                datosArticulos.setearParametro("@Id", ID);
                datosArticulos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datosImagenes.cerraConexion();
                datosArticulos.cerraConexion();
            }
        }


        public void AgregarImagen(Imagen imagen)
        {

            AccesoDatos datos = new AccesoDatos();


            try
            {

                datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@id, @url)");
                datos.setearParametro("@id", imagen.IdArticulo);
                datos.setearParametro("@url", imagen.ImagenUrl);
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
