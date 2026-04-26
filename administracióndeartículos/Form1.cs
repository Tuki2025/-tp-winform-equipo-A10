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

public enum TipoEntidad { Marca, Categoria }

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

            cboCampo.Items.Add("Categorias");
            cboCampo.Items.Add("Marcas");
            cboCampo.Items.Add("Precio");
        }

        private void cargarListado()
        {
            ArticuloNegocio Negocio = new ArticuloNegocio();
            try
            {
                listaArticulos = Negocio.listar();
                dgvArticulos.DataSource = listaArticulos;

                manejoColumnas();

                if(dgvArticulos.Rows.Count > 0)
                {
                    dgvArticulos.CurrentCell = dgvArticulos.Rows[0].Cells[1]; //dejo pre seleccionada la primer fila
                }

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

                listaImagenes = seleccionado.Imagenes;
                indiceImagen = 0;

                if (seleccionado.Imagenes != null && seleccionado.Imagenes.Count > 0)
                {
                    Herramientas.cargarImagen(ptxArticulo, seleccionado.Imagenes[0].ImagenUrl);
                }
                else
                {
                    Herramientas.cargarImagen(ptxArticulo, null);
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
        private void dgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
                return;

            Articulos seleccionado = (Articulos)dgvArticulos.CurrentRow.DataBoundItem;

            frmDetalleArticulo frm = new frmDetalleArticulo(seleccionado, indiceImagen);
            frm.ShowDialog();
        }
        private void btAtras_Click(object sender, EventArgs e)
        {
            if (listaImagenes == null || listaImagenes.Count == 0)
                return;

            indiceImagen--;

            if (indiceImagen < 0)
                indiceImagen = listaImagenes.Count - 1;

            Herramientas.cargarImagen(ptxArticulo, listaImagenes[indiceImagen].ImagenUrl);
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (listaImagenes == null || listaImagenes.Count == 0) /*Revisa si la lista es nula o no tiene nada*/
                return;

            indiceImagen++; /*Suma un valor al indice*/

            if (indiceImagen >= listaImagenes.Count) /*Caso que el indice llegue a supera el tamaño maximo de la lista, el indice vuelve a cero*/
                indiceImagen = 0;

            Herramientas.cargarImagen(ptxArticulo, listaImagenes[indiceImagen].ImagenUrl); /*carga la imagen nomás*/
        }
        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCampo.SelectedItem == null) return;

            string opcion = cboCampo.SelectedItem.ToString();

            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }
        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarFiltro()) return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;

                dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool validarFiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione el campo para filtrar");
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione el criterio para filtrar");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Precio")
            {
                if (!Herramientas.checkNumero(txtFiltroAvanzado.Text))
                {
                    MessageBox.Show("Por favor solo ingrese numeros");
                    return true;
                }
            }
            return false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFiltroAvanzado.Clear();
            cboCampo.SelectedIndex = -1;
            cboCriterio.SelectedIndex = -1;
            cargarListado();
        }

        private void txtFiltroAvanzado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) //si se presiona Enter
            {
                btnAplicarFiltro_Click(sender, e);
            }
        }

        private void tsCategoriaAgregar_Click(object sender, EventArgs e)
        {
            frmMaestro ventana = new frmMaestro(TipoEntidad.Categoria);

            ventana.ShowDialog();

            cargarListado();
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaestro ventana = new frmMaestro(TipoEntidad.Categoria);
            ventana.ShowDialog(this);
            cargarListado();

        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaestro ventana = new frmMaestro(TipoEntidad.Marca);
            ventana.ShowDialog(this);
            cargarListado();

        }
    }
}
