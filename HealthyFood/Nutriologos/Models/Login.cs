using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nutriologos.Recursos_BO.BO_Inicio;
using System.Data.SqlClient;
using System.Data;

namespace Nutriologos.Models
{
    public class Login
    {

        Conexión_Base_de_Datos cone = new Conexión_Base_de_Datos();

        public int ValidarUsuario(LoginBO ObjBo)
        {
            string sql = "select Nombre_Usuario, Contraseña from Usuarios where Nombre_Usuario = '" + ObjBo.Usuario + "' AND Contraseña = '" + ObjBo.contraseña + "' ";
            return cone.EjecutarComando(sql);
        
        }


    }
}