using capaNegocio;
using capaEntidades;
using System;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class MT_clientes : Form
    {
        clienteBL cliente = new clienteBL();

        public MT_clientes()
        {
            InitializeComponent();
        }
        private void MT_clientes_Load(object sender, EventArgs e)
        {
            listar();
            bloqueo();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void bloqueo()
        {
            btn_agregar.Enabled = true;
            btn_eliminar.Enabled = false;
            btn_modificar.Enabled = false;
        }
        private void desbloqueo()
        {
            btn_agregar.Enabled = false;
            btn_eliminar.Enabled = true;
            btn_modificar.Enabled = true;
        }

        private void limpiar()
        {
            txt_telefono.Enabled = true;
            txt_telefono.Clear();
            txt_nombre.Clear();
            txt_telefono.Focus();
            txt_referencia.Clear();
            txt_direción.Clear();
            txt_email.Clear();
            bloqueo();
        }

        private void listar()
        {
            dataGridView1.DataSource = cliente.listado().Tables[0];
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 160;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
        }

 

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



 

        private void btn_agregar_Click(object sender, EventArgs e)
        {

            if (txt_telefono.Text == "" || txt_nombre.Text == "" || txt_direción.Text == "" || txt_referencia .Text=="" || txt_email.Text=="")
            {
                MessageBox.Show("Complete todos los datos..!!", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cliente.validartelefono(txt_telefono.Text))
            {
                MessageBox.Show("El codigo ya se encuentra registrado!!", "Error en codigo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            ClienteEntity cli = new ClienteEntity();
            cli.celular= txt_telefono.Text;
           cli.nombre = txt_nombre.Text;
           cli.email = txt_email.Text;
            cli.referencia = txt_referencia.Text;
            cli.direccion = txt_direción.Text;
            cliente.guardar(cli);
            listar();
            limpiar();

        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea modificar el Registro", "modificar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {

                if (txt_telefono.Text == "" || txt_nombre.Text == "" || txt_direción.Text == "" || txt_referencia.Text == "" || txt_email.Text == "")
                {
                    MessageBox.Show("Complete todos los datos..!!", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ClienteEntity cli = new ClienteEntity();
                cli.celular = txt_telefono.Text;
                cli.nombre = txt_nombre.Text;
                cli.direccion = txt_direción.Text;
                cli.referencia = txt_referencia.Text;
                cli.email = txt_email.Text;
                cliente.modificar(cli);
                listar();
                limpiar();
            }
        }

        private void LIMPIA_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el Registro", "eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                ClienteEntity cli = new ClienteEntity();
                cli.celular = txt_telefono.Text;
                cliente.eliminar(cli);
                listar();
                limpiar();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_telefono.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_nombre.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_direción.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_referencia.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txt_email.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txt_telefono.Enabled = false;
            desbloqueo();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MT_clientes_Load_1(object sender, EventArgs e)
        {
            listar();
            bloqueo();
        }
    }
}
