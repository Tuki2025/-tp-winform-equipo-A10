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
        private List<Articulos> listaArticulos;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarListado();
        }

        private void cargarListado()
        {
            ArticuloNegocio Negocio = new ArticuloNegocio();
            try
            {
                listaArticulos = Negocio.listar();
                dgvArticulos.DataSource = listaArticulos;

                manejoColumnas();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulos seleccionado = (Articulos)dgvArticulos.CurrentRow.DataBoundItem;
                ArticuloNegocio negocio = new ArticuloNegocio();

                try
                {
                    List<Imagen> imagenes = negocio.listarImagenes(seleccionado.ID);

                    if (imagenes != null && imagenes.Count > 0)
                    {
                        ptxArticulo.Load(imagenes[0].ImagenUrl);
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
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
            cargarListado();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Articulos seleccionado;
            seleccionado = (Articulos)dgvArticulos.CurrentRow.DataBoundItem;

            frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
            modificar.ShowDialog();
       
            cargarListado();
        }
        private void cargarImagenDefault()
        {
            ptxArticulo.Load("https://img.freepik.com/free-vector/illustration-gallery-icon_53876-27002.jpg");
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            buscar();
        }
        private void buscar()
        {
            List<Articulos> listaFiltrada;
            string filtro = txtBusqueda.Text;

            if (filtro.Length >= 3)
            {
                listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower()) || 
                x.Marca.Descripcion.ToLower().Contains(filtro.ToLower()) || 
                x.Categoria.Descripcion.ToLower().Contains(filtro.ToLower()));
            }
            else
            {
                listaFiltrada = listaArticulos;
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            manejoColumnas();
        }
        private void manejoColumnas()
        {
            dgvArticulos.Columns["ID"].Visible = false;
            dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "C2";
        }
    }
}
