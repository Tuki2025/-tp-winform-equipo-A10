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

namespace administracióndeartículos
{
    public partial class frmDetalleArticulo : Form
    {
        private Articulos articulo = null;
        public frmDetalleArticulo()
        {
            InitializeComponent();
        }
        public frmDetalleArticulo(Articulos articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void frmDetalleArticulo_Load(object sender, EventArgs e)
        {
            try { 
                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtMarca.Text = articulo.Marca.Descripcion;
                    txtCategoria.Text = articulo.Categoria.Descripcion;
                    cargarImagen();
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void cargarImagen()
        {
            try
            {
                if (articulo != null && articulo.Imagenes != null && articulo.Imagenes.Count > 0)
                {
                    ptxImagen.Load(articulo.Imagenes[0].ImagenUrl);
                }
                else
                {
                    cargarImagenDefault();
                }
            }
            catch (Exception)
            {
                cargarImagenDefault();
            }
        }

        private void cargarImagenDefault()
        {
            ptxImagen.Load("https://img.freepik.com/free-vector/illustration-gallery-icon_53876-27002.jpg");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
