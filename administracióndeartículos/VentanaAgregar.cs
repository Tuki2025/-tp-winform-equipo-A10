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
        private Articulos articulo = null;/*creo un atributo de tipo articulo para usarlo en el constructor de modificacion, y asi cargar los datos del articulo a modificar en los campos correspondientes*/
        public frmAltaArticulo()
        {
            InitializeComponent();
        }
        public frmAltaArticulo(Articulos articulo)//cargo lo que seleccione en la primer ventana
        {            
            {
                InitializeComponent();
                 this.articulo = articulo;
                Text = "Modificar Artículo";
            }

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

                cboMarca.DataSource = null;
                cboCategoria.DataSource = null;

                List<Marca> listaMarcas = marcaNegocio.listar();
                List<Categoria> listaCategorias = categoriaNegocio.listar();




                //cargar combos primero
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "ID";
                cboMarca.DisplayMember = "Descripcion";

                cboCategoria.DataSource=categoriaNegocio.listar();
                cboCategoria.ValueMember = "ID";//propiedad que se va a guardar en la base de datos
                cboCategoria.DisplayMember = "Descripcion";//propiedad que se va a mostrar en el desplegable
                //carga de articulo

                if (articulo != null)/*si el articulo es distinto de null, es porque se esta usando el constructor de modificacion, entonces cargo los datos del articulo a modificar en los campos correspondientes*/
                {
                  

                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Decripcion;
                    txtPrecio.Text = articulo.Precio.ToString();



                     cboMarca.SelectedValue = articulo.Marca.ID;
                     cboCategoria.SelectedValue = articulo.Categoria.ID;// precarga de articulo a modificar en los campos correspondientes*/
                    //cargarImagen (articulo.UrlImagen);
                }  
            } 
            catch(Exception ex)
            {

              MessageBox.Show(ex.ToString())  ;
            }
        
        
        }
    }

}
