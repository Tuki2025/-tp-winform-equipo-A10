using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace administracióndeartículos
{
    public partial class frmAltaArticulo : Form
    {
        private Articulos articulo = null;

        // ===== ERROR PROVIDER =====
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public frmAltaArticulo()
        {
            InitializeComponent();
            ajustarDiseño(false);
        }

        public frmAltaArticulo(Articulos articulo)
        {
            InitializeComponent();
            ajustarDiseño(true);

            this.articulo = articulo;
            cargarListBox(articulo);
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                // ===== CONFIG ERROR PROVIDER =====
                errorProvider1.ContainerControl = this;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

                // ===== COMBOS =====
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "ID";
                cboMarca.DisplayMember = "Descripcion";

                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "ID";
                cboCategoria.DisplayMember = "Descripcion";

                // ===== AUTOCOMPLETE =====
                cboMarca.DropDownStyle = ComboBoxStyle.DropDown;
                cboMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboMarca.AutoCompleteSource = AutoCompleteSource.ListItems;

                cboCategoria.DropDownStyle = ComboBoxStyle.DropDown;
                cboCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();

                    cboMarca.SelectedValue = articulo.Marca.ID;
                    cboCategoria.SelectedValue = articulo.Categoria.ID;
                }
                else
                {
                    cboMarca.SelectedIndex = -1;
                    cboCategoria.SelectedIndex = -1;
                }

                // ===== LIMPIAR ERRORES AUTOMÁTICO =====
                txtCodigo.TextChanged += (s, ev) => errorProvider1.SetError(txtCodigo, "");
                txtNombre.TextChanged += (s, ev) => errorProvider1.SetError(txtNombre, "");
                txtPrecio.TextChanged += (s, ev) => errorProvider1.SetError(txtPrecio, "");
                txtUrlImagen.TextChanged += (s, ev) => errorProvider1.SetError(txtUrlImagen, "");
                txtUrlImgMod.TextChanged += (s, ev) => errorProvider1.SetError(txtUrlImgMod, "");
                cboMarca.SelectedIndexChanged += (s, ev) => errorProvider1.SetError(cboMarca, "");
                cboCategoria.SelectedIndexChanged += (s, ev) => errorProvider1.SetError(cboCategoria, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // ===== VALIDACIÓN =====
            if (!ValidarCampos())
                return;

            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (articulo == null)
                    articulo = new Articulos();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;

                // ===== ALTA: agregar imagen si hay =====
                if (articulo.ID == 0 && !string.IsNullOrWhiteSpace(txtUrlImagen.Text))
                {
                    if (articulo.Imagenes == null)
                        articulo.Imagenes = new List<Imagen>();

                    Imagen nuevaImg = new Imagen();
                    nuevaImg.ImagenUrl = txtUrlImagen.Text;
                    articulo.Imagenes.Add(nuevaImg);
                }

                if (articulo.ID != 0)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ===== VALIDACIONES =====
        private bool ValidarCampos()
        {
            bool valido = true;
            Control primerError = null;

            LimpiarErrores();

            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                errorProvider1.SetError(txtCodigo, "El código es obligatorio");
                if (primerError == null) primerError = txtCodigo;
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El nombre es obligatorio");
                if (primerError == null) primerError = txtNombre;
                valido = false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
            {
                errorProvider1.SetError(txtPrecio, "Precio inválido (≥ 0)");
                if (primerError == null) primerError = txtPrecio;
                valido = false;
            }

            // ===== VALIDAR URL ALTA =====
            if (!string.IsNullOrWhiteSpace(txtUrlImagen.Text))
            {
                if (!Uri.IsWellFormedUriString(txtUrlImagen.Text, UriKind.Absolute))
                {
                    errorProvider1.SetError(txtUrlImagen, "URL inválida");
                    if (primerError == null) primerError = txtUrlImagen;
                    valido = false;
                }
            }

            // ===== VALIDAR URL MODIFICACIÓN =====
            if (!string.IsNullOrWhiteSpace(txtUrlImgMod.Text))
            {
                if (!Uri.IsWellFormedUriString(txtUrlImgMod.Text, UriKind.Absolute))
                {
                    errorProvider1.SetError(txtUrlImgMod, "URL inválida");
                    if (primerError == null) primerError = txtUrlImgMod;
                    valido = false;
                }
            }

            if (cboMarca.SelectedItem == null)
            {
                errorProvider1.SetError(cboMarca, "Seleccione una marca");
                if (primerError == null) primerError = cboMarca;
                valido = false;
            }

            if (cboCategoria.SelectedItem == null)
            {
                errorProvider1.SetError(cboCategoria, "Seleccione una categoría");
                if (primerError == null) primerError = cboCategoria;
                valido = false;
            }

            if (!valido)
                primerError.Focus();

            return valido;
        }

        private void LimpiarErrores()
        {
            errorProvider1.SetError(txtCodigo, "");
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtPrecio, "");
            errorProvider1.SetError(txtUrlImagen, "");
            errorProvider1.SetError(txtUrlImgMod, "");
            errorProvider1.SetError(cboMarca, "");
            errorProvider1.SetError(cboCategoria, "");
        }

        // ===== RESTO DE TU CÓDIGO (sin cambios) =====

        private void cargarListBox(Articulos art)
        {
            lbxImagenes.Items.Clear();

            foreach (var img in art.Imagenes)
                lbxImagenes.Items.Add(img.ImagenUrl);
        }

        private void ajustarDiseño(bool esModificacion)
        {
            if (esModificacion)
            {
                Text = "Modificar Artículo";
                lblTitulo.Text = "Modificar Artículo";
                this.Width = 800;
                lblImagen.Visible = false;
                txtUrlImagen.Visible = false;
                lblUrlImgMod.Visible = true;
                txtUrlImgMod.Visible = true;
                btnAgregar.Visible = true;
                btnEliminar.Visible = true;
                lbxImagenes.Visible = true;
            }
            else
            {
                this.Width = 600;
                lblImagen.Visible = true;
                txtUrlImagen.Visible = true;
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
                lbxImagenes.Visible = false;
                lblUrlImgMod.Visible = false;
                txtUrlImgMod.Visible = false;
            }

            centrarBotones();
        }

        private void centrarBotones()
        {
            int espacio = 80;
            int ancho = btnAceptar.Width + espacio + btnCancelar.Width;
            int inicioX = (this.ClientSize.Width - ancho) / 2;

            btnAceptar.Location = new Point(inicioX, btnAceptar.Location.Y);
            btnCancelar.Location = new Point(inicioX + btnAceptar.Width + espacio, btnCancelar.Location.Y);
        }

        private void lbxImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxImagenes.SelectedItem != null)
            {
                string url = lbxImagenes.SelectedItem.ToString();
                txtUrlImgMod.Text = url;
                cargarImagen(url);
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }

        private void cargarImagen(string imagen)
        {
            try { pbxImagen.Load(imagen); }
            catch { cargarImagenDefault(); }
        }

        private void cargarImagenDefault()
        {
            pbxImagen.Load("https://img.freepik.com/free-vector/illustration-gallery-icon_53876-27002.jpg");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImgMod.Text);

            if (!string.IsNullOrWhiteSpace(txtUrlImgMod.Text))
            {
                Imagen nuevaImg = new Imagen();
                nuevaImg.ImagenUrl = txtUrlImgMod.Text;
                nuevaImg.IdArticulo = articulo.ID;

                articulo.Imagenes.Add(nuevaImg);
                cargarListBox(articulo);
                txtUrlImgMod.Clear();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lbxImagenes.SelectedItem != null)
            {
                int i = lbxImagenes.SelectedIndex;
                articulo.Imagenes.RemoveAt(i);
                cargarListBox(articulo);
                txtUrlImgMod.Clear();
                cargarImagenDefault();
            }
            else
            {
                MessageBox.Show("Seleccione una imagen para eliminar.");
            }
        }
    }
}