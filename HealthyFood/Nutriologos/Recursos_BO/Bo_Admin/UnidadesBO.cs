using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nutriologos.Recursos_BO.Bo_Admin
{
    public class UnidadesBO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<SelectListItem> Cities { set; get; }
    }
}