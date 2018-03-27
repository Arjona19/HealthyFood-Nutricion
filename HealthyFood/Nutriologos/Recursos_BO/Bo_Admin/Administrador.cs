using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nutriologos.Recursos_BO.Bo_Admin
{
    public class Administrador
    {
        public int id { set; get; }
        public string Nombre { set; get; }
        public string Contraseña { set; get; }
        public string Correo { set; get; }

        public int Id_Tipo { set; get; }

    }
}