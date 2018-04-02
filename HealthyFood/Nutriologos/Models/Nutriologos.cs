using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Nutriologos.Models
{
    public class Nutriologos
    {
        Conexión_Base_de_Datos conex = new Conexión_Base_de_Datos();
        public DataTable Tabla_Nutriologo_Presentacion()
        {
            string Con_SQL = string.Format("select U.Id,U.Nombre, U.Correo, N.Edad, N.Cedula, T.Nombre as 'Tipo' from Usuarios U inner join Nutriologo N on U.Id = N.Id_Usuario inner join [Tipo Usuario] T on T.Id = U.Id_Tipo where T.Nombre = 'Nutriologo' ");
            return conex.Tabla_Consultada(Con_SQL);
        }

    }
}