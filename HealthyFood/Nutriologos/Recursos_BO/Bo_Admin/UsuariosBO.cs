using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nutriologos.Recursos_BO.Bo_Admin
{
    public class UsuariosBO
    {
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public string Talla { get; set; }
        public string Enfermedad { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
        public string Contraseña { get; set; }
    }
}