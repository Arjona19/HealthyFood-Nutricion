using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nutriologos.Recursos_BO.Bo_Admin;
using System.Data;

namespace Nutriologos.Models
{
    public class Empresas
    {
        Conexión_Base_de_Datos conex = new Conexión_Base_de_Datos();
        public DataTable Tabla_Empresas_Presentacion()
        {
            string Con_SQL = string.Format("select U.Id,U.Nombre,U.Usuario ,U.Correo,E.Direccion, t.Nombre as 'Tipo' from Usuarios U inner join Empresa E ON E.Id_Usuario = U.Id inner join [Tipo Usuario] T on U.Id_Tipo = T.Id ");
            return conex.Tabla_Consultada(Con_SQL);
        }
    }
}