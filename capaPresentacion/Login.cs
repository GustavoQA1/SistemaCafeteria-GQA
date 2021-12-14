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
    public partial class Login : Form
    {

        usuarioBL usuario = new usuarioBL();
       

        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txt_usuario.Text == "" || txt_clave.Text == "")
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DataSet data = usuario.loginUsuario(txt_usuario.Text, txt_clave.Text);

                if (data.Tables[0].Rows.Count == 1)
                {
                    global.usuario = txt_usuario.Text;
                    global.nombre = data.Tables[0].Rows[0].ItemArray[1].ToString();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Datos Incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception)
            {
             
               //accion de log 

            }
            


        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
