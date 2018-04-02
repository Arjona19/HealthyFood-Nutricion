using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nutriologos.Recursos_BO.Bo_Admin;
using System.Data;

namespace Nutriologos.Models
{
    public class Enfermedades
    {
        Conexión_Base_de_Datos conex = new Conexión_Base_de_Datos();

        public int Agregar_Enfermedad(EnfermedadBO ObjP)
        {
            string sql = "insert into Enfermedad (Nombre, Valor) values ('" + ObjP.Nombre + "', '" + ObjP.Valor + "')";
            return conex.EjecutarComando(sql);
        }

        public DataTable Tabla_Enfermedad()
        {
            string Con_SQL = string.Format("select Id, Nombre, Valor from Enfermedad");
            return conex.Tabla_Consultada(Con_SQL);
        }
        public int Eliminar_Enfermedad(EnfermedadBO obj)
        {
            string sql = "Delete from Enfermedad where Id = '" + obj.Id + "'";
            return conex.EjecutarComando(sql);
        }

    }
}