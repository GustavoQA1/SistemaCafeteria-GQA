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
    public partial class BUS_cliente : Form
    {
        public string celular = "";
        public string nombre = "";

        public BUS_cliente()
        {
            InitializeComponent();
        }

        private void BUS_cliente_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void cargarClientes()
        {
            clienteBL cliente = new clienteBL();
            dataGridView1.DataSource = cliente.listado().Tables[0];
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            clienteBL cliente = new clienteBL();
            dataGridView1.DataSource = cliente.listado(txt_buscar.Text).Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            celular = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Close();
        }
    }
}
