using Proyecto_SistemaIntranet.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_SistemaIntranet.Models;
namespace Proyecto_SistemaIntranet.Controllers
{
    public class DashboardController : Controller
    {
        private SistemaIntranetEntities db = new SistemaIntranetEntities();
        // GET: Dashboard
        public ActionResult Principal()
        {
            // List<Menu> menuUsuario = (List<Menu>) Session["Menu"];
            Usuario objUsuario = (Usuario)Session["Usuario"];
            
            if(objUsuario != null)
            {
                //Buscamos los accesos que tiene el usuario
                var menuUsuario = (from m in db.usp_user_acceso(objUsuario.idrol, objUsuario.idusuario) select m);
                //Nombre del Rol de Usuario
                string nombreRol = (from r in db.Rol where r.idrol == objUsuario.idrol select r.descripcion).FirstOrDefault();
                // ViewBag.menu = menuUsuario;
                //ViewBag.usuario = objUsuario;
                //ViewBag.nombreRol = nombreRol;
                Session["Rol"] = nombreRol;
                Session["Menu"] = menuUsuario.ToList();


                return View(Session["Menu"]);

            }

            return RedirectToAction("Login","Login");

        }

        [AutorizacionUsuario(idAcceso:1)]
        public ActionResult Index()
        {
            return View();
        }

        [AutorizacionUsuario(idAcceso: 2)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AutorizacionUsuario(idAcceso: 3)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}