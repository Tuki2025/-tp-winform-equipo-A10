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
    public partial class frmAltaArticulo : Form
    {
        public frmAltaArticulo()
        {
            InitializeComponent();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulos art = new Articulos();
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                art.Codigo = txtCodigo.Text;
                art.Nombre = txtNombre.Text;
                art.Decripcion = txtDescripcion.Text;
                art.Precio = decimal.Parse(txtPrecio.Text);
                art.Marca = (Marca)cboMarca.SelectedItem;
                art.Categoria = (Categoria)cboCategoria.SelectedItem;
                
                negocio.agregar(art);
                MessageBox.Show("Agregado exitosamente");
                Close();
            }
            catch (Exception ex)
            {





                MessageBox.Show(ex.ToString());
            
            }
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try {
                cboMarca.DataSource = marcaNegocio.listar();
                cboCategoria.DataSource=categoriaNegocio.listar();
            } 
            catch(Exception ex)
            {


              MessageBox.Show(ex.ToString())  ;
            }
        
        
        
        
        
        
        }
    }

}
