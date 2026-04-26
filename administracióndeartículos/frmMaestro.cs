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
    public partial class frmMaestro : Form
    {
        private TipoEntidad tipo;
        private dynamic negocio; // Esto permite que el mismo código sirva para ambos negocios

        // Recibe el tipo (Marca o Categoria) desde el Form1
        public frmMaestro(TipoEntidad tipo)
        {
            InitializeComponent();
            this.tipo = tipo;

            // Configuramos el negocio una sola vez según el caso
            if (this.tipo == TipoEntidad.Marca)
                negocio = new MarcaNegocio();
            else
                negocio = new CategoriaNegocio();
        }

        private void frmMaestro_Load(object sender, EventArgs e)
        {
            this.Text = "Gestión de " + tipo.ToString();//cambia el titulo solo
            cargar();
            //  Desactivar botones de acción hasta que se seleccione algo
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void cargar()
        {
            // Gracias a 'dynamic', dgvDatos recibe lo que devuelva .listar() sea cual sea el negocio
            dgvDatos.DataSource = negocio.listar();

            // Ocultamos el ID para que quede más lindo
            if (dgvDatos.Columns["Id"] != null)
                dgvDatos.Columns["Id"].Visible = false;
        }

        // Al tocar una fila, el texto aparece en el TextBox
        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                dynamic seleccionado = dgvDatos.CurrentRow.DataBoundItem;
                txtDescripcion.Text = seleccionado.Descripcion;
            }
            else
            {
                // Si por alguna razón no hay selección, se vuelven a desactivar
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                txtDescripcion.Clear();
            }
        }

        

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, escribí una descripción.");
                return;
            }

            if (checkExistencia(txtDescripcion.Text))
            {
                MessageBox.Show("La " + tipo.ToString().ToLower() + " que intena agregar ya existe");

                return;
            }

            // Creamos el objeto dinámicamente según corresponda
            dynamic nuevo = (tipo == TipoEntidad.Marca) ? (object)new Marca() : (object)new Categoria();
            nuevo.Descripcion = txtDescripcion.Text;

            negocio.agregar(nuevo);
            MessageBox.Show(tipo.ToString() + " agregada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cargar();
            txtDescripcion.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
          
                   // 1. Validación de selección: verificamos que haya una fila seleccionada
            if (dgvDatos.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccioná un ítem de la lista para modificar.");
                return;
            }

            // 2. Validación de texto: que no intenten guardar algo vacío
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía.");
                return;
            }

            try
            {
                // 3. Obtenemos el objeto de la fila actual
                dynamic seleccionado = dgvDatos.CurrentRow.DataBoundItem;

                // 4. Le asignamos el nuevo texto del TextBox
                seleccionado.Descripcion = txtDescripcion.Text;

                // 5. Mandamos a la base de datos
                negocio.modificar(seleccionado);

                MessageBox.Show("Modificado correctamente.");

                // 6. Refrescamos la grilla
                cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.ToString());
            }
        }

        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;
            if (MessageBox.Show("¿Seguro que querés eliminar?", "Atención", MessageBoxButtons.YesNo) == DialogResult.No) return;

            dynamic seleccionado = dgvDatos.CurrentRow.DataBoundItem;
            negocio.eliminar(seleccionado.ID);
            cargar();
            txtDescripcion.Clear();
        }

        private bool checkExistencia(string texto)
        {
            var lista = (IEnumerable<object>)dgvDatos.DataSource; //me guardo el listado de la grilla

            if (lista != null)
            {
                foreach (dynamic item in lista)
                {
                    if (item.Descripcion.ToString().ToLower() == texto.ToLower())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

