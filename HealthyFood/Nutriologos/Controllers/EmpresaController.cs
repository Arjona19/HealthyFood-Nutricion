using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nutriologos.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inicio()
        {
            Models.Nutriologos Modal = new Models.Nutriologos();

            return View(Modal.Tabla_Nutriologo_Presentacion());
        }





    }
}