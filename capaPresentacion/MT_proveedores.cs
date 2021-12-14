using capaEntidades;
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
    public partial class MT_proveedores : Form
    {
        proveedorBL proveedor = new proveedorBL();

        public MT_proveedores()
        {
            InitializeComponent();
        }

        private void MT_proveedores_Load(object sender, EventArgs e)
        {
            listar();
            bloqueo();
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
            txt_codigo.Enabled = true;
            txt_codigo.Clear();
            txt_nombre.Clear();
            txt_telefono.Clear();
            txt_codigo.Focus();
            bloqueo();
        }

        private void listar()
        {
            dataGridView1.DataSource = proveedor.Listado().Tables[0];
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 160;
            dataGridView1.Columns[2].Width = 100;
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text == "" || txt_nombre.Text == "" || txt_telefono.Text=="")
            {
                MessageBox.Show("Complete todos los datos..!!", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (proveedor.validarCodigo(int.Parse(txt_codigo.Text)))
            {
                MessageBox.Show("El codigo ya se encuentra registrado!!", "Error en codigo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProveedoresEntity prov = new ProveedoresEntity();
            prov.codigo = int.Parse(txt_codigo.Text);
            prov.nombre = txt_nombre.Text;
            prov.telefono = txt_telefono.Text;
            proveedor.guardar(prov);
            listar();
            limpiar();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea modificar el Registro", "modificar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {

                if (txt_codigo.Text == "" || txt_nombre.Text == "" || txt_telefono.Text=="")
                {
                    MessageBox.Show("Complete todos los datos..!!", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ProveedoresEntity prov = new ProveedoresEntity();
                prov.codigo = int.Parse(txt_codigo.Text);
                prov.nombre = txt_nombre.Text;
                prov.telefono = txt_telefono.Text;
                proveedor.modificar(prov);
                listar();
                limpiar();
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el Registro", "eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                ProveedoresEntity prov = new ProveedoresEntity();
                prov.codigo = int.Parse(txt_codigo.Text);
                proveedor.eliminar(prov);
                listar();
                limpiar();
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_codigo.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_nombre.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_telefono.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_codigo.Enabled = false;
            desbloqueo();
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = proveedor.buscar(txt_buscar.Text).Tables[0];
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 160;
            dataGridView1.Columns[2].Width = 100;
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            global.GridAExcel(dataGridView1);
        }
    }
}
