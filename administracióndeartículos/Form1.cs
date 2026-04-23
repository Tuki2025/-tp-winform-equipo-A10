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
        private List<Imagen> listaImagenes;
        private int indiceImagen = 0;
        private int IdAux;

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

                cargarImagen(seleccionado);
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
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un artículo para modificar.");
                return;
            }

            Articulos seleccionado = dgvArticulos.CurrentRow.DataBoundItem as Articulos;

            if (seleccionado == null)
            {
                MessageBox.Show("Error al obtener el artículo seleccionado.");
                return;
            }

            try
            {
                frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
                modificar.ShowDialog();
                cargarListado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cargarImagen(Articulos art)
        {
            
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                listaImagenes = negocio.listarImagenes(art.ID);
                IdAux = art.ID;
                indiceImagen = 0;

                if (art.Imagenes != null && art.Imagenes.Count > 0)
                {   

                    ptxArticulo.Load(art.Imagenes[indiceImagen].ImagenUrl);
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

       
        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un artículo primero.");
                return;
            }

            Articulos seleccionado = dgvArticulos.CurrentRow.DataBoundItem as Articulos;

            if (seleccionado == null)
            {
                MessageBox.Show("Error al obtener el artículo seleccionado.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro que desea eliminar el artículo?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(seleccionado.ID);
                    cargarListado();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
                return;

            Articulos seleccionado = (Articulos)dgvArticulos.CurrentRow.DataBoundItem;

            frmDetalleArticulo frm = new frmDetalleArticulo(seleccionado);
            frm.ShowDialog();
        }


        private void MovimientoImagen(string url)
        {
            try
            {
                ptxArticulo.Load(url);
            }
            catch
            {
                cargarImagenDefault();
            }
        }


        private void btAtras_Click(object sender, EventArgs e)
        {
            if (listaImagenes == null || listaImagenes.Count == 0)
                return;

            indiceImagen--;

            if (indiceImagen < 0)
                indiceImagen = listaImagenes.Count - 1;

            MovimientoImagen(listaImagenes[indiceImagen].ImagenUrl);
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (listaImagenes == null || listaImagenes.Count == 0) /*Revisa si la lista es nula o no tiene nada*/
                return;

            indiceImagen++; /*Suma un valor al indice*/

            if (indiceImagen >= listaImagenes.Count) /*Caso que el indice llegue a supera el tamaño maximo de la lista, el indice vuelve a cero*/
                indiceImagen = 0;

            MovimientoImagen(listaImagenes[indiceImagen].ImagenUrl); /*carga la imagen nomás*/
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarImagen alta = new frmAgregarImagen();
            alta.idArt = IdAux;
            alta.ShowDialog();
        }
    }
}
