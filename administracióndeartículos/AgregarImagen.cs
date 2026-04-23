using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace administracióndeartículos
{
    public partial class frmAgregarImagen : Form
    {
        
        private Imagen imagen = null;
        private List<Imagen> listaImagenes;
        public int idArt { get; set; }


        public frmAgregarImagen()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();


            try
            {
                if (imagen == null)/*si el articulo es null, es porque se esta usando el constructor de alta, entonces creo un nuevo articulo para cargar los datos del nuevo articulo a agregar*/
                {
                    imagen = new Imagen();
                }

                imagen.IdArticulo = idArt;
                imagen.ImagenUrl = txtUrl.Text;

                negocio.AgregarImagen(imagen);
                MessageBox.Show("Agregado exitosamente");
                
                Close();
                
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());


            }
        }
    
    
    
     
    
    
    
    
    
    
    
    
    }
}
