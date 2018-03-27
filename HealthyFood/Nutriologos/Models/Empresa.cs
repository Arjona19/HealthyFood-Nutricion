using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nutriologos.Recursos_BO.Bo_Admin;
using System.Data;

namespace Nutriologos.Models
{
    public class Empresa
    {
        Conexión_Base_de_Datos conex = new Conexión_Base_de_Datos();

        public int Agregar_Empreza_1(Administrador ObjP)
        {
            string sql = "Insert into Administrador (Nombre, Contraseña, Correo, Id_tipo]) values ('" + ObjP.Nombre + "', '"+ ObjP.Contraseña +"', '" +ObjP.Contraseña + "', '"+ObjP.Id_Tipo + "' )";
            return conex.EjecutarComando(sql);
        }

        public int Agregar_Empreza_2(EmpresaBO ObjP)
        {
            string sql = "Insert into Empresa (Nombre, Contraseña, Correo, Id_tipo]) values ('" + ObjP.Direccion + "' )";
            return conex.EjecutarComando(sql);
        }


        public int Eliminar_Empresa(Administrador ObjP)
        {
            string sql = "Delete from Administrador where ID = '" + ObjP.id + "'";
            return conex.EjecutarComando(sql);
        }

        public int Actualizar_Empreza(Administrador ObjP)
        {
            string sql = "Update Administrador Set Nombre='" + ObjP.Nombre + "' where ID='" + ObjP.id + "'";
            return conex.EjecutarComando(sql);
        }


        //directo Empreza a modificar busqueda <<<-----------------------------------------------------------
        public ClasificacionBO Obtener_Clasificacion(int id)
        {
            var ex = new ClasificacionBO();
            String strBuscar = string.Format("Select Id, Nombre FROM Clasificaciones where Id ={0}", id);
            DataTable datos = conex.Tabla_Consultada(strBuscar);
            DataRow row = datos.Rows[0];
            ex.Id = Convert.ToInt32(row["Id"]);
            ex.Nombre = row["Nombre"].ToString();
            return ex;
        }

        public DataTable Tabla_Clasificacion()
        {
            string Con_SQL = string.Format("Select Id, Nombre FROM Clasificaciones");
            return conex.Tabla_Consultada(Con_SQL);
        }

        //busqueda tabla pendiente
        //select A.Nombre, A.Contraseña, A.Correo, A.Id_Tipo, E.Direccion, e.Id_Usuario from Administrador A inner join Empresa E on E.Id_Usuario = A.Id

    }

}