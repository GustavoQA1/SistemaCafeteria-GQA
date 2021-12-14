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
    public partial class MenuCafeteria : Form
    {
        public MenuCafeteria()
        {
            InitializeComponent();
        }

        private void MenuCafeteria_Load(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.ShowDialog();

            estatus_nombre.Text = global.nombre;

        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MT_categorias obj = new MT_categorias();
           // obj.MdiParent = this;
            obj.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MT_proveedores obj = new MT_proveedores();
            obj.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MT_producto obj = new MT_producto();
            obj.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios obj = new Usuarios();
            obj.ShowDialog();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global.usuario = "";
            global.nombre = "";
            estatus_nombre.Text = "";
            Login obj = new Login();
            obj.ShowDialog();
        }

        private void pedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TR_Pedido obj = new TR_Pedido();
            obj.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MT_clientes obj = new MT_clientes();
            obj.ShowDialog();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
