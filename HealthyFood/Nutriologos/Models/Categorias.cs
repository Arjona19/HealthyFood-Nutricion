using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nutriologos.Recursos_BO.Bo_Admin;
using System.Data;

namespace Nutriologos.Models
{
    public class Categorias
    {
        Conexión_Base_de_Datos conex = new Conexión_Base_de_Datos();

        public int Agregar_Clasificacion(ClasificacionBO ObjP)
        {
            string sql = "insert into Clasificaciones (Nombre, [Valor Energia], [Valor Proteinas], [Valor Lipidos], [Valor Hidratos]) values ('" + ObjP.Nombre + "', '" + ObjP.Energia + "', '" + ObjP.Proteinas + "', '" + ObjP.Lipidos + "', '" + ObjP.Hidratos + "')";
            return conex.EjecutarComando(sql);
        }

        public int Eliminar_Clasificacion(ClasificacionBO ObjP)
        {
            string sql = "Delete from Clasificaciones where ID = '" + ObjP.Id + "'";
            return conex.EjecutarComando(sql);
        }

        public int Actualizar_Clasificacion(ClasificacionBO ObjP)
        {
            string sql = "Update Clasificaciones Set Nombre='" + ObjP.Nombre + "' where ID='" + ObjP.Id + "'";
            return conex.EjecutarComando(sql);
        }

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

    }
}