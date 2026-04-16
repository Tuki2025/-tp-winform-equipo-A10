using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "C";
        

        } 
    }
}
