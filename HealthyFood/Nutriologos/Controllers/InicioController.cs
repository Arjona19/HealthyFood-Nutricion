using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nutriologos.Recursos_BO.BO_Inicio;
using System.Data;
using System.Data.SqlClient;
using Nutriologos.Models;

namespace Nutriologos.Controllers
{
    public class InicioController : Controller
    {
        // Pagina de inicio
        public ActionResult Login()
        {
            return View();
        }
        //Motodo Para Loguearse
        public ActionResult Loguearse(string Nombre, string contraseña)
        {
            LoginBO validaciones = new LoginBO();

            validaciones.Usuario = Nombre;
            validaciones.contraseña = contraseña;

            Models.Login logueo = new Models.Login();

            logueo.ValidarUsuario(validaciones);

            if(logueo.ValidarUsuario(validaciones) != null)
            {
                return View("~/Views/Administrador/Inicio.cshtml");
            }
            else
            {
                return View("~/Views/Inicio/Login.cshtml");
            }


        }



    }
}