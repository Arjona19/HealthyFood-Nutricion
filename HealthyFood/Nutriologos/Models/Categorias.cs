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

        public DataTable Tabla_Clasificacion()
        {
            string Con_SQL = string.Format("select Id, Nombre, [Valor Hidratos], [Valor Energia], [Valor Lipidos], [Valor Proteinas] from Clasificaciones");
            return conex.Tabla_Consultada(Con_SQL);
        }
        public int Eliminar_Clasificacion(ClasificacionBO obj)
        {
            string sql = "Delete from Clasificaciones where Id = '" + obj.Id + "'";
            return conex.EjecutarComando(sql);
        }

    }
}