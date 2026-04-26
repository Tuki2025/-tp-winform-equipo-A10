using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace administracióndeartículos
{
    public partial class frmDetalleArticulo : Form
    {
        private Articulos articulo = null;
        private int indiceInicial;
        public frmDetalleArticulo()
        {
            InitializeComponent();
        }
        public frmDetalleArticulo(Articulos articulo, int indice)
        {
            InitializeComponent();
            this.articulo = articulo;
            this.indiceInicial = indice;
        }

        private void frmDetalleArticulo_Load(object sender, EventArgs e)
        {
            try 
            { 
                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtMarca.Text = articulo.Marca.Descripcion;
                    txtCategoria.Text = articulo.Categoria.Descripcion;

                    if (articulo.Imagenes != null && articulo.Imagenes.Count > indiceInicial)
                    {
                        string url = articulo.Imagenes[indiceInicial].ImagenUrl;
                        Herramientas.cargarImagen(ptxImagen, url);
                    }
                    else
                    {
                        Herramientas.cargarImagen(ptxImagen, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
