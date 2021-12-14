using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
   public class claseDatos
    {
        public SqlConnection conexion = new SqlConnection(@"Data Source=LAPTOP-QD9IHG0A\SQLEXPRESS;Initial Catalog=cafeteria;User ID=sa;Password=Noelia19#");

        public void Conectar() {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
        }

        public void Desconectar() {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }

        public DataSet Listado(string query)
        {
            Conectar();
            DataSet dt = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(query, conexion);
            ad.Fill(dt);
            Desconectar();
            return dt;
        }

        public int ejecutar(string query)
        {
            Conectar();
            SqlCommand com = new SqlCommand(query, conexion);
            int numero = com.ExecuteNonQuery();
            Desconectar();
            return numero;
        }

    }
}
