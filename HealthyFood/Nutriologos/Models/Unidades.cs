using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nutriologos.Recursos_BO.Bo_Admin;
using System.Data;

namespace Nutriologos.Models
{
    public class Unidades
    {
        Conexión_Base_de_Datos conex = new Conexión_Base_de_Datos();

        public int Agregar_Tipo_Unidad(UnidadBO ObjP)
        {
            string sql = "Insert into [Tipo de Unidad] (Nombre) values ('" + ObjP.Nombre + "')";
            return conex.EjecutarComando(sql);
        }

        public int Eliminar_Tipo_Unidad(UnidadBO ObjP)
        {
            string sql = "Delete from [Tipo de Unidad] where ID = '" + ObjP.Id + "'";
            return conex.EjecutarComando(sql);
        }

        public int Actualizar_Tipo_Unidad(UnidadBO ObjP)
        {
            string sql = "Update [Tipo de Unidad] Set Nombre='" + ObjP.Nombre + "' where ID='" + ObjP.Id + "'";
            return conex.EjecutarComando(sql);
        }

        public UnidadBO Obtener_Tipo_Unidad(int id)
        {
            var ex = new UnidadBO();
            String strBuscar = string.Format("Select Id, Nombre FROM [Tipo de Unidad] where Id ={0}", id);
            DataTable datos = conex.Tabla_Consultada(strBuscar);
            DataRow row = datos.Rows[0];
            ex.Id = Convert.ToInt32(row["Id"]);
            ex.Nombre = row["Nombre"].ToString();
            return ex;
        }

        public DataTable Tabla_Tipo_Unidad()
        {
            string Con_SQL = string.Format("Select Id, Nombre FROM [Tipo de Unidad]");
            return conex.Tabla_Consultada(Con_SQL);
        }

    }
}