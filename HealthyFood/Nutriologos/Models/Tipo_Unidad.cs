using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Nutriologos.Recursos_BO.Bo_Admin;
using Nutriologos.Models;

namespace Nutriologos.Models
{
    public class Tipo_Unidad
    {
        Conexión_Base_de_Datos conex = new Conexión_Base_de_Datos();

        public int Agregar_Unidad(UnidadesBO ObjP)
        {
            string sql = "insert into [Tipo de Unidad] (Nombre) values ('" + ObjP.Nombre + "')";
            return conex.EjecutarComando(sql);
        }

        public DataTable Tabla_Unidad()
        {
            string Con_SQL = string.Format("select Id, Nombre from [Tipo de Unidad]");
            return conex.Tabla_Consultada(Con_SQL);
        }
        public int Eliminar_Unidad(UnidadesBO obj)
        {
            string sql = "Delete from [Tipo de Unidad] where Id = '" + obj.Id + "'";
            return conex.EjecutarComando(sql);
        }

    }
}