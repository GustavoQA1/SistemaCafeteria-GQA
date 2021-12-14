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
    public partial class Usuarios : Form
    {
        usuarioBL usuario = new usuarioBL();

        public Usuarios()
        {
            InitializeComponent();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {

            if (validarDatos(0))
            {
                return;
            }
            
            UsuariosEntity user = new UsuariosEntity();
            user.codigo = txt_codigo.Text;
            user.nombre = txt_nombre.Text;
            user.clave = txt_clave.Text;
            usuario.guardar(user);
            listar();
            limpiar();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea modificar el Registro", "modificar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {

                if (validarDatos(1))
                {
                    return;
                }

                UsuariosEntity user = new UsuariosEntity();
                user.codigo = txt_codigo.Text;
                user.nombre = txt_nombre.Text;
                user.clave = txt_clave.Text;
                usuario.modificar(user);
                listar();
                limpiar();
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el Registro", "eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                UsuariosEntity user = new UsuariosEntity();
                user.codigo = txt_codigo.Text;
                usuario.eliminar(user);
                listar();
                limpiar();
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = usuario.buscar(txt_buscar.Text).Tables[0];
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 160;
            dataGridView1.Columns[2].Width = 100;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_codigo.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_nombre.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_codigo.Enabled = false;
            desbloqueo();
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            global.GridAExcel(dataGridView1);
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
            txt_clave.Clear();
            txt_reclave.Clear();
            txt_codigo.Focus();
            bloqueo();
        }

        private void listar()
        {
            dataGridView1.DataSource = usuario.Listado().Tables[0];
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 160;
            dataGridView1.Columns[2].Width = 100;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            listar();
            bloqueo();
        }

        private bool validarDatos(int tipo) {

            bool estado = false;

            if (txt_codigo.Text == "" || txt_nombre.Text == "" || txt_clave.Text == "")
            {
                MessageBox.Show("Complete todos los datos..!!", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                estado = true;
                return estado;
            }

            if (tipo == 0 && usuario.validarCodigo(txt_codigo.Text))
            {
                MessageBox.Show("El codigo ya se encuentra registrado!!", "Error en codigo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                estado = true;
                return estado;
            }

            if (txt_clave.Text.Length < 8)
            {
                MessageBox.Show("La clave no tienen el largo minimo de 8..!!", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                estado = true;
                return estado;
            }

            if (txt_clave.Text != txt_reclave.Text)
            {
                MessageBox.Show("La clave no coincide..!!", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                estado = true;
                return estado;
            }

            return estado;

        }

    }
}
