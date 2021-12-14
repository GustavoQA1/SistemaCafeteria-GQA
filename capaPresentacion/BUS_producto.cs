using capaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class BUS_producto : Form
    {

        public string codigo = "";
        public string nombre = "";
        public string precio = "";

        public BUS_producto()
        {
            InitializeComponent();
        }

        private void BUS_producto_Load(object sender, EventArgs e)
        {
            listarProductos();
        }

        private void listarProductos()
        {
            productoBL producto = new productoBL();
            dataGridView1.DataSource = producto.Listado().Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codigo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            precio = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            Close();
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            productoBL producto = new productoBL();
            dataGridView1.DataSource = producto.Listado(txt_buscar.Text).Tables[0];
        }
    }
}
