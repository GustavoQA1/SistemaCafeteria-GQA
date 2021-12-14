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
using capaEntidades;
namespace capaPresentacion
{
    public partial class MT_producto : Form
    {
        proveedorBL proveedor = new proveedorBL();
        categoriaBL categoria = new categoriaBL();
        productoBL producto = new productoBL();
        public MT_producto()
        {
            InitializeComponent();
        }

        private void MT_producto_Load(object sender, EventArgs e)
        {
            listar();
            cargarCategoria();
            cargarProveedor();
        }
        private void listar()
        {
            dataGridView1.DataSource = producto.Listado().Tables[0];
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
        }
        public void cargarCategoria() {
            cb_categoria.DataSource = categoria.Listado().Tables[0];
            cb_categoria.ValueMember = "codigo";
            cb_categoria.DisplayMember = "nombre";
        }
        public void cargarProveedor()
        {
            cb_proveedor.DataSource = proveedor.Listado().Tables[0];
            cb_proveedor.ValueMember = "codigo";
            cb_proveedor.DisplayMember = "nombre";
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {

            if (txt_codigo.Text == "" || txt_nombre.Text == "" || txt_precio.Text == "" || cb_categoria.Text == "" || cb_proveedor.Text == "")
            {
                MessageBox.Show("Complete todos los datos..!!", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (producto.validarCodigo(int.Parse(txt_codigo.Text)))
            {
                MessageBox.Show("El codigo ya se encuentra registrado!!", "Error en codigo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProductosEntity prod = new ProductosEntity();
            prod.codigo = int.Parse(txt_codigo.Text);
            prod.nombre = txt_nombre.Text;
            prod.precio = int.Parse(txt_precio.Text);
            prod.cod_categoria = int.Parse(cb_categoria.SelectedValue.ToString());
            prod.cod_proveedor = int.Parse(cb_proveedor.SelectedValue.ToString());
            producto.guardar(prod);
            listar();
           // limpiar();
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
