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
    public partial class MT_categorias : Form
    {
        categoriaBL categoria = new categoriaBL();

        public MT_categorias()
        {
            InitializeComponent();
        }

        private void MT_categorias_Load(object sender, EventArgs e)
        {
            listar();
            bloqueo();
        }

        private void bloqueo() {
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

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar() {
            txt_codigo.Enabled = true;
            txt_codigo.Clear();
            txt_nombre.Clear();
            txt_codigo.Focus();
            bloqueo();
        }

        private void listar() {
            dataGridView1.DataSource = categoria.Listado().Tables[0];
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 235;
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text == "" || txt_nombre.Text == "")
            {
                MessageBox.Show("Complete todos los datos..!!","Error de datos",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (categoria.validarCodigo(int.Parse(txt_codigo.Text)))
            {
                MessageBox.Show("El codigo ya se encuentra registrado!!", "Error en codigo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CategoriasEntity cat = new CategoriasEntity();
            cat.codigo = int.Parse(txt_codigo.Text);
            cat.nombre = txt_nombre.Text;
            categoria.guardar(cat);
            listar();
            limpiar();
        }

        private void txt_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          txt_codigo.Text =  dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
          txt_nombre.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
          txt_codigo.Enabled = false;
          desbloqueo();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea modificar el Registro", "modificar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {

                if (txt_codigo.Text == "" || txt_nombre.Text == "")
                {
                    MessageBox.Show("Complete todos los datos..!!", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CategoriasEntity cat = new CategoriasEntity();
                cat.codigo = int.Parse(txt_codigo.Text);
                cat.nombre = txt_nombre.Text;
                categoria.modificar(cat);
                listar();
                limpiar();
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Desea eliminar el Registro", "eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                CategoriasEntity cat = new CategoriasEntity();
                cat.codigo = int.Parse(txt_codigo.Text);
                categoria.eliminar(cat);
                listar();
                limpiar();
            }
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = categoria.buscar(txt_buscar.Text).Tables[0];
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 235;
        }

        private void txt_codigo_Leave(object sender, EventArgs e)
        {
            if (txt_codigo.Text != "")
            {
                if (categoria.validarCodigo(int.Parse(txt_codigo.Text)))
                {
                    MessageBox.Show("El codigo ya se encuentra registrado!!", "Error en codigo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_codigo.Text = "";
                    txt_codigo.Focus();
                }
            }
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            global.GridAExcel(dataGridView1);
        }
    }
}
