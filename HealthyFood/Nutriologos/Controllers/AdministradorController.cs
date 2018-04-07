using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nutriologos.Recursos_BO;
using Nutriologos.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Data;

namespace Nutriologos.Controllers
{
    public class AdministradorController : Controller
    {

        string nombre, energia, proteina, hidrato, lipido, fibra;
        string unidad, clasificacion;

        // Pgina Principal
        public ActionResult Inicio()
        {
            return View();
        }
        public PartialViewResult obDatos(int ID)
        {
            Ingredientes modal = new Models.Ingredientes();
            return PartialView("Modal_parcial", modal.TablaIngredientes_(ID));
        }
        //Pagina de ingredientes
        public ActionResult Ingredientes()
        {
            Ingredientes modal = new Models.Ingredientes();
            ViewBag.Nombre = nombre;
            ViewBag.unidad = unidad;
            ViewBag.clasificacion = clasificacion;
            ViewBag.energia = energia;
            ViewBag.proteina = proteina;
            ViewBag.hidrato = hidrato;
            ViewBag.lipido = lipido;
            ViewBag.fibra = fibra;

            return View(modal.TablaIngredientes());
        }
        //Pagina de la clasificacion de los ingredientes
        public ActionResult Clasificaciones()
        {
            Categorias modal = new Categorias();
            ViewBag.Nombre = nombre;
            ViewBag.energia = energia;
            ViewBag.proteina = proteina;
            ViewBag.hidrato = hidrato;
            ViewBag.lipido = lipido;

            return View(modal.Tabla_Clasificacion());
        }
        //Pagina de Enfermedades
        public ActionResult Enfermedades()
        {
            Enfermedades modal = new Models.Enfermedades();
            ViewBag.Nombre = nombre;
            ViewBag.Valor = energia;
            return View(modal.Tabla_Enfermedad());
        }
        //Perfil de los Nutriologos
        public ActionResult Nutriologos()
        {
            Models.Nutriologos Modal = new Models.Nutriologos();

            return View(Modal.Tabla_Nutriologo_Presentacion());
        }
        //Perfil de los Pacientes
        public ActionResult Pacientes()
        {
            return View();
        }
        //Pagina de Ganancias
        public ActionResult Pagos()
        {
            return View();
        }
        public ActionResult Empresas()
        {
            Empresas modal = new Models.Empresas();

            return View(modal.Tabla_Empresas_Presentacion());
        }
        //en esta parte de agregan los tipos de unidad (gramas, kilos, onzas etc...)
        public ActionResult Unidad()
        {
            Tipo_Unidad modal = new Tipo_Unidad();
            ViewBag.Nombre = nombre;
            return View(modal.Tabla_Unidad());
        }

        //seccion de altas para agregar datos

        public ActionResult Agregar_ingredientes(string Nombre, string Cantidad, string unidad, string Clasificacion, string energia, string Proteina, string lipido, string hidrato, string fibra)
        {
            Ingredientes obj_Modelo = new Models.Ingredientes();
            Recursos_BO.Bo_Admin.IngredientesBO obj_BO = new Recursos_BO.Bo_Admin.IngredientesBO();

            obj_BO.Nombre = Nombre;
            obj_BO.unidad = unidad;
            obj_BO.Cantidad = Cantidad;
            obj_BO.Id_Clasificion = Clasificacion;
            obj_BO.Energia = energia;
            obj_BO.Proteina = Proteina;
            obj_BO.Loquidos = lipido;
            obj_BO.Hidratos = hidrato;
            obj_BO.Fibra = fibra;

            obj_Modelo.AgregarIngrediente(obj_BO);
            Ingredientes();
            return View("Ingredientes");
        }
        public ActionResult Agregar_Clasificacion(string Nombre, string Energia, string Proteina, string Hidrato, string Lipido)
        {
            Categorias obj_Modelo = new Categorias();
            Recursos_BO.Bo_Admin.ClasificacionBO obj_BO = new Recursos_BO.Bo_Admin.ClasificacionBO();

            obj_BO.Nombre = Nombre;
            obj_BO.Energia = Energia;
            obj_BO.Proteinas = Proteina;
            obj_BO.Hidratos = Hidrato;
            obj_BO.Lipidos = Lipido;

            obj_Modelo.Agregar_Clasificacion(obj_BO);
            Clasificaciones();

            return View("Clasificaciones");
        }
        public ActionResult Agregar_unidad(string Nombre)
        {
            Tipo_Unidad obj_model = new Tipo_Unidad();
            Recursos_BO.Bo_Admin.UnidadesBO obj_BO = new Recursos_BO.Bo_Admin.UnidadesBO();

            obj_BO.Nombre = Nombre;
            obj_model.Agregar_Unidad(obj_BO);
            Unidad();
            return View("Unidad");
        }

        public ActionResult Agregar_Enfermedad(string Nombre, string Valor)
        {
            Enfermedades obj_Modelo = new Models.Enfermedades();
            Recursos_BO.Bo_Admin.EnfermedadBO obj_BO = new Recursos_BO.Bo_Admin.EnfermedadBO();

            obj_BO.Nombre = Nombre;
            obj_BO.Valor = Valor;

            obj_Modelo.Agregar_Enfermedad(obj_BO);
            Enfermedades();

            return View("enfermedades");
        }

        //en esta seccion de hacen las consultas de los datos para antes de actualizar
        public ActionResult Consultar_Categoria(Recursos_BO.Bo_Admin.ClasificacionBO obj)
        {

            int id = obj.Id;
            Conexión_Base_de_Datos con = new Conexión_Base_de_Datos();
            SqlCommand cmd = new SqlCommand("select Nombre, [Valor Hidratos], [Valor Energia], [Valor Lipidos], [Valor Proteinas] from Clasificaciones where Id = '" + id + "' ", con.ConectarBD());
            con.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                nombre = dr["Nombre"].ToString();
                energia = dr["Valor Energia"].ToString();
                proteina = dr["Valor Proteinas"].ToString();
                hidrato = dr["Valor Hidratos"].ToString();
                lipido = dr["Valor Lipidos"].ToString();
            }
            Clasificaciones();
            return View("Clasificaciones");
        }

        public ActionResult Consultar_Unidad(Recursos_BO.Bo_Admin.UnidadesBO obj)
        {
            int id = obj.Id;
            Conexión_Base_de_Datos con = new Conexión_Base_de_Datos();
            SqlCommand cmd = new SqlCommand("select Nombre from [Tipo de Unidad]  where Id = '" + id + "' ", con.ConectarBD());
            con.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                nombre = dr["Nombre"].ToString();
            }
            Unidad();
            return View("Unidad");
        }

        public ActionResult Consultar_Enfermedad(Recursos_BO.Bo_Admin.EnfermedadBO obj)
        {
            int id = obj.Id;
            Conexión_Base_de_Datos con = new Conexión_Base_de_Datos();
            SqlCommand cmd = new SqlCommand("select Nombre, Valor from Enfermedad where Id = '" + id + "' ", con.ConectarBD());
            con.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                nombre = dr["Nombre"].ToString();
                energia = dr["Valor"].ToString();
            }
            Enfermedades();
            return View("Enfermedades");
        }

        public ActionResult Consultar_Ingrediente(Recursos_BO.Bo_Admin.IngredientesBO obj)
        {

            int id = obj.Id;
            Conexión_Base_de_Datos con = new Conexión_Base_de_Datos();
            SqlCommand cmd = new SqlCommand("Select I.ID, I.Nombre, I.Imagen, I.Energia, I.Proteina, I.Liquidos, I.Hidratos, I.Fibra, C.Nombre AS 'Clasificación', U.Nombre AS 'Unidad' FROM Ingredientes I inner join Clasificaciones C on I.Id_Clasificacion = C.Id inner join [Tipo de Unidad] U on I.Id_Unidad = U.Id where I.Id = '" + id + "' ", con.ConectarBD());
            con.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                nombre = dr["Nombre"].ToString();
                unidad = dr["Unidad"].ToString();
                clasificacion = dr["Clasificación"].ToString();
                energia = dr["Energia"].ToString();
                proteina = dr["Proteina"].ToString();
                hidrato = dr["Hidratos"].ToString();
                lipido = dr["Liquidos"].ToString();
                fibra = dr["Fibra"].ToString();

            }
            Ingredientes();
            return View("Ingredientes");
        }

        //Esta seccion es de eliminado de algun paramatro
        public ActionResult Eliminar_Categoria(Recursos_BO.Bo_Admin.ClasificacionBO oEnf)
        {
            Categorias enfM = new Categorias();
            enfM.Eliminar_Clasificacion(oEnf);
            Clasificaciones();
            return View("Clasificaciones");
        }
        public ActionResult Eliminar_Unidad(Recursos_BO.Bo_Admin.UnidadesBO oEnf)
        {
            Tipo_Unidad enfM = new Tipo_Unidad();
            enfM.Eliminar_Unidad(oEnf);
            Unidad();
            return View("Unidad");
        }

        public ActionResult Eliminar_Enfermedad(Recursos_BO.Bo_Admin.EnfermedadBO oEnf)
        {
            Enfermedades enfM = new Models.Enfermedades();
            enfM.Eliminar_Enfermedad(oEnf);
            Enfermedades();
            return View("Enfermedades");
        }
        public ActionResult Eliminar_Ingrediente(Recursos_BO.Bo_Admin.IngredientesBO obj)
        {  
            Ingredientes modal = new Models.Ingredientes();
            modal.EliminarIngrediente(obj);
            Ingredientes();
            return View("Ingredientes");
        }

        //drop down list de prueba
        public ActionResult Dropdownlist()
        {
            List<Recursos_BO.Bo_Admin.UnidadesBO> NombreUnidad = new List<Recursos_BO.Bo_Admin.UnidadesBO>();
            Conexión_Base_de_Datos Con = new Conexión_Base_de_Datos();
            SqlCommand cmd = new SqlCommand("select id, Nombre from [Tipo de Unidad]", Con.ConectarBD());
            Con.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read() == true)
            {
                Recursos_BO.Bo_Admin.UnidadesBO UN = new Recursos_BO.Bo_Admin.UnidadesBO();
                UN.Id = Convert.ToInt32(dr["id"]);
                UN.Nombre = dr[1].ToString();
                NombreUnidad.Add(UN);
            }

            return View(NombreUnidad);
        }
        public Recursos_BO.Bo_Admin.IngredientesBO[] Datos(int ID)
        {
            int i; 
            Ingredientes modal = new Ingredientes();
            DataTable datos = new DataTable();
            datos = modal.TablaIngredientes_(ID);
            Recursos_BO.Bo_Admin.IngredientesBO[] obj = new Recursos_BO.Bo_Admin.IngredientesBO[datos.Rows.Count];
            i = 0;
            while (i < datos.Rows.Count)
            {
                obj[i] = new Recursos_BO.Bo_Admin.IngredientesBO();
             
                obj[i].Nombre = datos.Rows[i]["Nombre"].ToString();
                obj[i].Id_Clasificion = datos.Rows[i]["Clasificacion"].ToString();
                obj[i].Energia = datos.Rows[i]["Energia"].ToString();
                obj[i].Proteina = datos.Rows[i]["Proteina"].ToString();
                obj[i].Hidratos = datos.Rows[i]["Hidrato"].ToString();
                obj[i].Loquidos = datos.Rows[i]["Lipido"].ToString();
                obj[i].Fibra = datos.Rows[i]["Fibra"].ToString();
            }
            return obj;

        }

    }
}