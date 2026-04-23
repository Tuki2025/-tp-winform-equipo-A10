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
        private int idAux;
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
            
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (articulo == null)/*si el articulo es null, es porque se esta usando el constructor de alta, entonces creo un nuevo articulo para cargar los datos del nuevo articulo a agregar*/
                {
                    articulo = new Articulos();
                }

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);

                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;

                Imagen nuevaImg = new Imagen();
                nuevaImg.ImagenUrl = txtUrlImagen.Text;
                articulo.Imagenes.Add(nuevaImg);
               
                if(articulo.ID !=0)
                {
                   negocio.modificar(articulo);
                   MessageBox.Show("Modificado exitosamente");
                }
                else
                { 
                   negocio.agregar(articulo);
                   MessageBox.Show("Agregado exitosamente");
                }
                  
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
                    txtDescripcion.Text = articulo.Descripcion;
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
