using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nutriologos.Recursos_BO.Bo_Admin
{
    public class IngredientesBO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Energia { get; set; }
        public string Proteina { get; set; }
        public string Loquidos { get; set; }
        public string Hidratos { get; set; }
        public string Fibra{ get; set; }
        public int Id_Clasificion { get; set; }

    }
}