using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nutriologos.Recursos_BO.Bo_Admin;
using System.Data;

namespace Nutriologos.Models
{
    public class Nutriologo
    {


        Conexión_Base_de_Datos conex = new Conexión_Base_de_Datos();

        public int Agregar_Empreza_1(Administrador ObjP)
        {
            string sql = "Insert into Administrador (Nombre, Contraseña, Correo, Id_tipo]) values ('" + ObjP.Nombre + "', '" + ObjP.Contraseña + "', '" + ObjP.Contraseña + "', '" + ObjP.Id_Tipo + "' )";
            return conex.EjecutarComando(sql);
        }

        public int Agregar_Empreza_2(EmpresaBO ObjP)
        {
            string sql = "Insert into Empresa (Nombre, Contraseña, Correo, [Id_tipo]) values ('" + ObjP.Direccion + "' )";
            return conex.EjecutarComando(sql);
        }


        public int Eliminar_Empresa(Administrador ObjP)
        {
            string sql = "Delete from Administrador where ID = '" + ObjP.id + "'";
            return conex.EjecutarComando(sql);
        }


    }
}