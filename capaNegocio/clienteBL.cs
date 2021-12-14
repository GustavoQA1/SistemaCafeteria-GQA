using capaDatos;
using capaEntidades;
using System;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocio
{
    public class clienteBL
    {
        claseDatos dato = new claseDatos();


        public bool validartelefono(String telefono)
        {
            DataSet obj = dato.Listado("SELECT * FROM CLIENTES WHERE CELULAR=" + telefono + "");
            if (obj.Tables[0].Rows.Count == 1)
                return true;
            else
                return false;

        }
        public DataSet listado()
        {
            return dato.Listado("SELECT TOP (200) celular, nombre, email, direccion, referencia FROM clientes");
        }
        public DataSet listado(string texto)
        {
            return dato.Listado("SELECT TOP (200) celular, nombre, email, direccion, referencia FROM clientes where nombre like '%"+ texto + "%' or celular like '%" + texto + "%'");
        }
        public int guardar(ClienteEntity cliente)
        {
            return dato.ejecutar("INSERT INTO CLIENTES(CELULAR,NOMBRE,EMAIL,DIRECCION,REFERENCIA) VALUES('" + cliente.celular + "','" + cliente.nombre + "','" + cliente.email + "','"+cliente.direccion +"','"+cliente.referencia+"' )");
        }
        public int eliminar(ClienteEntity cliente)
        {
            return dato.ejecutar("DELETE FROM  CLIENTES WHERE CELULAR='" + cliente.celular + "'");
        }
        public int modificar(ClienteEntity cliente)
        {
            return dato.ejecutar("UPDATE CLIENTES SET NOMBRE='" + cliente.nombre + "',EMAIL='" + cliente.email + "',DIRECCION='" + cliente.direccion + "',REFERENCIA='" + cliente.referencia + "' WHERE CELULAR=" + cliente.celular + "");
        }

        
    }
}
