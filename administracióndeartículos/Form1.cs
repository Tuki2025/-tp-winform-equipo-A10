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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArticuloNegocio Negocio = new ArticuloNegocio();
            dgvArticulos.DataSource = Negocio.listar();
            dgvArticulos.Columns["ID"].Visible=false;
            dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "C2";
        

        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulos seleccionado = (Articulos)dgvArticulos.CurrentRow.DataBoundItem;

            ArticuloNegocio negocio = new ArticuloNegocio();

            List<Imagen> imagenes = negocio.listarImagenes(seleccionado.ID);

            try
            {

                ptxArticulo.Load(imagenes[0].ImagenUrl);
            }
            catch {

                ptxArticulo.Load("https://images7.memedroid.com/images/UPLOADED652/5dc091d0d876f.jpeg");


            } 



        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
        }
    }
}
