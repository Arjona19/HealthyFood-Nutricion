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
        Login Modal = new Models.Login();
        string Nombre;
        int bandera = 0;

        // Pagina de inicio
        public ActionResult Login()
        {
            return View();
        }
        //Motodo Para Loguearse
        public ActionResult Principal(string Usuario, string Contraseña)
        {

            if (Usuario != null && Contraseña != null)
            {

                DataTable datos = Modal.Inicio_sesion(Usuario, Contraseña);
                if (datos.Rows.Count == 1)
                {
                    bandera = 1;
                    Nombre = datos.Rows[0][5].ToString();
                    if (datos.Rows[0][1].ToString() == "2")
                    {

                        Session["Nombre"] = "Usuario " + Nombre;

                    }
                    else if (datos.Rows[0][1].ToString() == "3")
                    {

                        Session["Nombre"] = "Administrador " + Nombre;
                        return View("~/Views/Administrador/Inicio.cshtml");
                    }
                }
                else
                {
                    bandera = 3;
                }

            }

            switch (bandera)
            {
                case 1:
                    ViewBag.SessionActive = 1;
                    break;
                case 2:
                    ViewBag.Register = 2;
                    break;
                case 3:
                    ViewBag.Error = 3;
                    break;
                case 4:
                    ViewBag.Warning = 4;
                    break;
                default:
                    break;
            }



            return View();
        }



    }
}