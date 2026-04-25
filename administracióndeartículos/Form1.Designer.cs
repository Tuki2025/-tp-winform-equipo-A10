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
            this.tsCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCategoriaAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCategoriaModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCategoriaEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMarcas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMarcasAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMarcasModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMarcasEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.tsVer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVerCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVerMarcas = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.btAtras = new System.Windows.Forms.Button();
            this.btSiguiente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptxArticulo)).BeginInit();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(46, 262);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btModificar
            // 
            this.btModificar.Location = new System.Drawing.Point(234, 262);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(75, 23);
            this.btModificar.TabIndex = 4;
            this.btModificar.Text = "Modificar";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.Location = new System.Drawing.Point(402, 262);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(75, 23);
            this.btEliminar.TabIndex = 5;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // lbBusqueda
            // 
            this.lbBusqueda.AutoSize = true;
            this.lbBusqueda.Location = new System.Drawing.Point(12, 35);
            this.lbBusqueda.Name = "lbBusqueda";
            this.lbBusqueda.Size = new System.Drawing.Size(55, 13);
            this.lbBusqueda.TabIndex = 7;
            this.lbBusqueda.Text = "Busqueda";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(15, 51);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(328, 20);
            this.txtBusqueda.TabIndex = 8;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // ptxArticulo
            // 
            this.ptxArticulo.Location = new System.Drawing.Point(625, 96);
            this.ptxArticulo.Name = "ptxArticulo";
            this.ptxArticulo.Size = new System.Drawing.Size(419, 392);
            this.ptxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptxArticulo.TabIndex = 10;
            this.ptxArticulo.TabStop = false;
            // 
            // tsCategorias
            // 
            this.tsCategorias.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCategoriaAgregar,
            this.tsCategoriaModificar,
            this.tsCategoriaEliminar});
            this.tsCategorias.Name = "tsCategorias";
            this.tsCategorias.Size = new System.Drawing.Size(75, 22);
            this.tsCategorias.Text = "Categorias";
            // 
            // tsCategoriaAgregar
            // 
            this.tsCategoriaAgregar.Name = "tsCategoriaAgregar";
            this.tsCategoriaAgregar.Size = new System.Drawing.Size(125, 22);
            this.tsCategoriaAgregar.Text = "Agregar";
            // 
            // tsCategoriaModificar
            // 
            this.tsCategoriaModificar.Name = "tsCategoriaModificar";
            this.tsCategoriaModificar.Size = new System.Drawing.Size(125, 22);
            this.tsCategoriaModificar.Text = "Modificar";
            // 
            // tsCategoriaEliminar
            // 
            this.tsCategoriaEliminar.Name = "tsCategoriaEliminar";
            this.tsCategoriaEliminar.Size = new System.Drawing.Size(125, 22);
            this.tsCategoriaEliminar.Text = "Eliminar";
            // 
            // tsMarcas
            // 
            this.tsMarcas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMarcasAgregar,
            this.tsMarcasModificar,
            this.tsMarcasEliminar});
            this.tsMarcas.Name = "tsMarcas";
            this.tsMarcas.Size = new System.Drawing.Size(57, 22);
            this.tsMarcas.Text = "Marcas";
            // 
            // tsMarcasAgregar
            // 
            this.tsMarcasAgregar.Name = "tsMarcasAgregar";
            this.tsMarcasAgregar.Size = new System.Drawing.Size(125, 22);
            this.tsMarcasAgregar.Text = "Agregar";
            // 
            // tsMarcasModificar
            // 
            this.tsMarcasModificar.Name = "tsMarcasModificar";
            this.tsMarcasModificar.Size = new System.Drawing.Size(125, 22);
            this.tsMarcasModificar.Text = "Modificar";
            // 
            // tsMarcasEliminar
            // 
            this.tsMarcasEliminar.Name = "tsMarcasEliminar";
            this.tsMarcasEliminar.Size = new System.Drawing.Size(125, 22);
            this.tsMarcasEliminar.Text = "Eliminar";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCategorias,
            this.tsMarcas,
            this.tsVer});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip2.Size = new System.Drawing.Size(1053, 24);
            this.menuStrip2.TabIndex = 12;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // tsVer
            // 
            this.tsVer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVerCategorias,
            this.tsVerMarcas});
            this.tsVer.Name = "tsVer";
            this.tsVer.Size = new System.Drawing.Size(35, 22);
            this.tsVer.Text = "Ver";
            // 
            // tsVerCategorias
            // 
            this.tsVerCategorias.Name = "tsVerCategorias";
            this.tsVerCategorias.Size = new System.Drawing.Size(130, 22);
            this.tsVerCategorias.Text = "Categorias";
            // 
            // tsVerMarcas
            // 
            this.tsVerMarcas.Name = "tsVerMarcas";
            this.tsVerMarcas.Size = new System.Drawing.Size(130, 22);
            this.tsVerMarcas.Text = "Marcas";
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvArticulos.Location = new System.Drawing.Point(15, 96);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.RowHeadersWidth = 62;
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(604, 150);
            this.dgvArticulos.TabIndex = 13;
            this.dgvArticulos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulos_CellContentClick);
            this.dgvArticulos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulos_CellDoubleClick);
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // btAtras
            // 
            this.btAtras.Location = new System.Drawing.Point(638, 494);
            this.btAtras.Name = "btAtras";
            this.btAtras.Size = new System.Drawing.Size(75, 23);
            this.btAtras.TabIndex = 14;
            this.btAtras.Text = "Atras";
            this.btAtras.UseVisualStyleBackColor = true;
            this.btAtras.Click += new System.EventHandler(this.btAtras_Click);
            // 
            // btSiguiente
            // 
            this.btSiguiente.Location = new System.Drawing.Point(956, 494);
            this.btSiguiente.Name = "btSiguiente";
            this.btSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btSiguiente.TabIndex = 15;
            this.btSiguiente.Text = "Siguiente";
            this.btSiguiente.UseVisualStyleBackColor = true;
            this.btSiguiente.Click += new System.EventHandler(this.btSiguiente_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 589);
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
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptxArticulo)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem tsCategorias;
        private System.Windows.Forms.ToolStripMenuItem tsMarcas;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Button btAtras;
        private System.Windows.Forms.Button btSiguiente;
        private System.Windows.Forms.ToolStripMenuItem tsCategoriaAgregar;
        private System.Windows.Forms.ToolStripMenuItem tsCategoriaModificar;
        private System.Windows.Forms.ToolStripMenuItem tsCategoriaEliminar;
        private System.Windows.Forms.ToolStripMenuItem tsMarcasAgregar;
        private System.Windows.Forms.ToolStripMenuItem tsMarcasModificar;
        private System.Windows.Forms.ToolStripMenuItem tsMarcasEliminar;
        private System.Windows.Forms.ToolStripMenuItem tsVer;
        private System.Windows.Forms.ToolStripMenuItem tsVerCategorias;
        private System.Windows.Forms.ToolStripMenuItem tsVerMarcas;
    }
}

