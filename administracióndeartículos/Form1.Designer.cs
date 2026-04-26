namespace administracióndeartículos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btModificar = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.lbBusqueda = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.ptxArticulo = new System.Windows.Forms.PictureBox();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.btAtras = new System.Windows.Forms.Button();
            this.btSiguiente = new System.Windows.Forms.Button();
            this.tsCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMarcas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVerCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVerMarcas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.lblCampo = new System.Windows.Forms.Label();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.txtFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.btnAplicarFiltro = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.categoríasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ptxArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(150, 649);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(112, 35);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btModificar
            // 
            this.btModificar.Location = new System.Drawing.Point(417, 649);
            this.btModificar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(112, 35);
            this.btModificar.TabIndex = 4;
            this.btModificar.Text = "Modificar";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.Location = new System.Drawing.Point(684, 649);
            this.btEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(112, 35);
            this.btEliminar.TabIndex = 5;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // lbBusqueda
            // 
            this.lbBusqueda.AutoSize = true;
            this.lbBusqueda.Location = new System.Drawing.Point(18, 54);
            this.lbBusqueda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBusqueda.Name = "lbBusqueda";
            this.lbBusqueda.Size = new System.Drawing.Size(82, 20);
            this.lbBusqueda.TabIndex = 7;
            this.lbBusqueda.Text = "Busqueda";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(22, 78);
            this.txtBusqueda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(490, 26);
            this.txtBusqueda.TabIndex = 8;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // ptxArticulo
            // 
            this.ptxArticulo.Location = new System.Drawing.Point(933, 220);
            this.ptxArticulo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ptxArticulo.Name = "ptxArticulo";
            this.ptxArticulo.Size = new System.Drawing.Size(628, 603);
            this.ptxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptxArticulo.TabIndex = 10;
            this.ptxArticulo.TabStop = false;
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvArticulos.Location = new System.Drawing.Point(18, 220);
            this.dgvArticulos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.RowHeadersWidth = 62;
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(906, 420);
            this.dgvArticulos.TabIndex = 13;
            this.dgvArticulos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulos_CellContentClick);
            this.dgvArticulos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulos_CellDoubleClick);
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // btAtras
            // 
            this.btAtras.Location = new System.Drawing.Point(952, 832);
            this.btAtras.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAtras.Name = "btAtras";
            this.btAtras.Size = new System.Drawing.Size(112, 35);
            this.btAtras.TabIndex = 14;
            this.btAtras.Text = "Atras";
            this.btAtras.UseVisualStyleBackColor = true;
            this.btAtras.Click += new System.EventHandler(this.btAtras_Click);
            // 
            // btSiguiente
            // 
            this.btSiguiente.Location = new System.Drawing.Point(1430, 832);
            this.btSiguiente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSiguiente.Name = "btSiguiente";
            this.btSiguiente.Size = new System.Drawing.Size(112, 35);
            this.btSiguiente.TabIndex = 15;
            this.btSiguiente.Text = "Siguiente";
            this.btSiguiente.UseVisualStyleBackColor = true;
            this.btSiguiente.Click += new System.EventHandler(this.btSiguiente_Click);
            // 
            // tsCategorias
            // 
            this.tsCategorias.Name = "tsCategorias";
            this.tsCategorias.Size = new System.Drawing.Size(16, 29);
            // 
            // tsMarcas
            // 
            this.tsMarcas.Name = "tsMarcas";
            this.tsMarcas.Size = new System.Drawing.Size(16, 29);
            // 
            // tsVer
            // 
            this.tsVer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVerCategorias,
            this.tsVerMarcas});
            this.tsVer.Name = "tsVer";
            this.tsVer.Size = new System.Drawing.Size(53, 29);
            this.tsVer.Text = "Ver";
            // 
            // tsVerCategorias
            // 
            this.tsVerCategorias.Name = "tsVerCategorias";
            this.tsVerCategorias.Size = new System.Drawing.Size(198, 34);
            this.tsVerCategorias.Text = "Categorias";
            // 
            // tsVerMarcas
            // 
            this.tsVerMarcas.Name = "tsVerMarcas";
            this.tsVerMarcas.Size = new System.Drawing.Size(198, 34);
            this.tsVerMarcas.Text = "Marcas";
            // 
            // menuStrip2
            // 
            this.menuStrip2.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCategorias,
            this.categoríasToolStripMenuItem,
            this.marcasToolStripMenuItem,
            this.tsMarcas,
            this.tsVer});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1580, 33);
            this.menuStrip2.TabIndex = 12;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(18, 157);
            this.lblCampo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(60, 20);
            this.lblCampo.TabIndex = 16;
            this.lblCampo.Text = "Campo";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(264, 157);
            this.lblCriterio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(59, 20);
            this.lblCriterio.TabIndex = 17;
            this.lblCriterio.Text = "Criterio";
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(508, 157);
            this.lblFiltro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(44, 20);
            this.lblFiltro.TabIndex = 18;
            this.lblFiltro.Text = "Filtro";
            // 
            // cboCampo
            // 
            this.cboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(98, 152);
            this.cboCampo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(145, 28);
            this.cboCampo.TabIndex = 19;
            this.cboCampo.SelectedIndexChanged += new System.EventHandler(this.cboCampo_SelectedIndexChanged);
            // 
            // cboCriterio
            // 
            this.cboCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(342, 151);
            this.cboCriterio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(145, 28);
            this.cboCriterio.TabIndex = 20;
            // 
            // txtFiltroAvanzado
            // 
            this.txtFiltroAvanzado.Location = new System.Drawing.Point(572, 151);
            this.txtFiltroAvanzado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFiltroAvanzado.Name = "txtFiltroAvanzado";
            this.txtFiltroAvanzado.Size = new System.Drawing.Size(145, 26);
            this.txtFiltroAvanzado.TabIndex = 21;
            this.txtFiltroAvanzado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltroAvanzado_KeyPress);
            // 
            // btnAplicarFiltro
            // 
            this.btnAplicarFiltro.Location = new System.Drawing.Point(728, 149);
            this.btnAplicarFiltro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAplicarFiltro.Name = "btnAplicarFiltro";
            this.btnAplicarFiltro.Size = new System.Drawing.Size(93, 35);
            this.btnAplicarFiltro.TabIndex = 22;
            this.btnAplicarFiltro.Text = "Aplicar";
            this.btnAplicarFiltro.UseVisualStyleBackColor = true;
            this.btnAplicarFiltro.Click += new System.EventHandler(this.btnAplicarFiltro_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(830, 149);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(93, 35);
            this.btnReset.TabIndex = 23;
            this.btnReset.Text = "Resetear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // categoríasToolStripMenuItem
            // 
            this.categoríasToolStripMenuItem.Name = "categoríasToolStripMenuItem";
            this.categoríasToolStripMenuItem.Size = new System.Drawing.Size(202, 29);
            this.categoríasToolStripMenuItem.Text = "Gestión de Categorías";
            this.categoríasToolStripMenuItem.Click += new System.EventHandler(this.categoríasToolStripMenuItem_Click);
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(174, 29);
            this.marcasToolStripMenuItem.Text = "Gestión de Marcas";
            this.marcasToolStripMenuItem.Click += new System.EventHandler(this.marcasToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 897);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAplicarFiltro);
            this.Controls.Add(this.txtFiltroAvanzado);
            this.Controls.Add(this.cboCriterio);
            this.Controls.Add(this.cboCampo);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.btSiguiente);
            this.Controls.Add(this.btAtras);
            this.Controls.Add(this.dgvArticulos);
            this.Controls.Add(this.ptxArticulo);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.lbBusqueda);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de Artículos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptxArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Label lbBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.PictureBox ptxArticulo;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Button btAtras;
        private System.Windows.Forms.Button btSiguiente;
        private System.Windows.Forms.ToolStripMenuItem tsCategorias;
        private System.Windows.Forms.ToolStripMenuItem tsCategoriaAgregar;
        private System.Windows.Forms.ToolStripMenuItem tsCategoriaModificar;
        private System.Windows.Forms.ToolStripMenuItem tsCategoriaEliminar;
        private System.Windows.Forms.ToolStripMenuItem tsMarcas;
        private System.Windows.Forms.ToolStripMenuItem tsMarcasAgregar;
        private System.Windows.Forms.ToolStripMenuItem tsMarcasModificar;
        private System.Windows.Forms.ToolStripMenuItem tsMarcasEliminar;
        private System.Windows.Forms.ToolStripMenuItem tsVer;
        private System.Windows.Forms.ToolStripMenuItem tsVerCategorias;
        private System.Windows.Forms.ToolStripMenuItem tsVerMarcas;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cboCampo;
        private System.Windows.Forms.ComboBox cboCriterio;
        private System.Windows.Forms.TextBox txtFiltroAvanzado;
        private System.Windows.Forms.Button btnAplicarFiltro;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ToolStripMenuItem categoríasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
    }
}

