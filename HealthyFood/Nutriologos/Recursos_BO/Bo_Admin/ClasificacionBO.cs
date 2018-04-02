using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nutriologos.Recursos_BO.Bo_Admin
{
    public class ClasificacionBO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Energia { get; set; }
        public string Proteinas { get; set; }
        public string Lipidos { get; set; }
        public string Hidratos { get; set; }
    }
}