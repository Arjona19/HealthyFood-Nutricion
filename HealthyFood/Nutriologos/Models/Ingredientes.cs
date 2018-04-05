using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nutriologos.Recursos_BO.Bo_Admin;
using System.Data;

namespace Nutriologos.Models
{
    public class Ingredientes
    {

        Conexión_Base_de_Datos conex = new Conexión_Base_de_Datos();

        public int AgregarIngrediente(IngredientesBO ObjP) 
        {
            string sql = "Insert into Ingredientes (Nombre, Id_Unidad, Energia, Proteina, Liquidos, Hidratos, Fibra, Id_Clasificacion, Cantidad) values ('" + ObjP.Nombre + "', '" + ObjP.unidad + "', '" + ObjP.Energia + "', '" + ObjP.Proteina + "', '" + ObjP.Loquidos + "', '" + ObjP.Hidratos + "', '" + ObjP.Fibra + "', '" + ObjP.Id_Clasificion + "', '" + ObjP.Cantidad + "')";
            return conex.EjecutarComando(sql);

        }


        public int EliminarIngrediente(IngredientesBO ObjP)
        {
            string sql = "Delete from Ingredientes where ID = '" + ObjP.Id + "'";

            return conex.EjecutarComando(sql);

        }

        public int ActualizarrIngrediente(IngredientesBO ObjP)
        {
            string sql = "Update Ingredientes Set Nombre='" + ObjP.Nombre + "' where ID='" + ObjP.Id + "'";
            return conex.EjecutarComando(sql);

        }

        public IngredientesBO ObtenerIngredientes(int Id)
        {
            var ex = new IngredientesBO();
            String strBuscar = string.Format("Select ID, Nombre FROM Ingredientes where ID = {0}", Id);
            DataTable datos = conex.Tabla_Consultada(strBuscar);
            DataRow row = datos.Rows[0];
            ex.Id = Convert.ToInt32(row["ID_Clasificacion"]);
            ex.Nombre = row["Medida"].ToString();
            return ex;
        }

        public DataTable TablaIngredientes()
        {
            string Con_SQL = string.Format("Select I.ID, I.Nombre, I.Imagen, I.Energia, I.Proteina, I.Liquidos, I.Hidratos, I.Fibra, C.Nombre AS 'Clasificación', U.Nombre AS 'Unidad' FROM Ingredientes I inner join Clasificaciones C on I.Id_Clasificacion = C.Id inner join [Tipo de Unidad] U on I.Id_Unidad = U.Id");
            return conex.Tabla_Consultada(Con_SQL);
        }
        public DataTable TablaIngredientes_(int ID)
        {
            string Con_SQL = string.Format("Select ID, Nombre FROM Ingredientes where ID = {0}", ID);
            return conex.Tabla_Consultada(Con_SQL);
        }
    }
}