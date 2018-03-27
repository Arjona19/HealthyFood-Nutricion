using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nutriologos.Recursos_BO.Bo_Admin
{
    public class Nutriologo
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Edad { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Cedula { get; set; }
    }
}