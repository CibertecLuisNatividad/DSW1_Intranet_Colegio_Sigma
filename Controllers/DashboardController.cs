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
        Usuario usuario;
        // GET: Dashboard
        public ActionResult Principal()
        {
            // List<Menu> menuUsuario = (List<Menu>) Session["Menu"];
            usuario = (Usuario)Session["Usuario"];
            
            if(usuario != null)
            {
                return View();
            }

            return RedirectToAction("Login","Login");

        }

        public ActionResult Perfil()
        {
            usuario = (Usuario)Session["Usuario"];

            if (usuario.idrol == 2)
            {
                return RedirectToAction("PerfilAlumno", "Dashboard");
            }
            return RedirectToAction("PerfilUsuario", "Dashboard");
        }

        public ActionResult PerfilAlumno()
        {
            Apoderado apoderado;
            usuario = (Usuario)Session["Usuario"];
 
            var ap = (from a in db.Apoderado where a.idusuario == usuario.idusuario select a).FirstOrDefault();
            if (ap != null)
            {
                apoderado = ap;
            }
            else
            {
                apoderado = new Apoderado()
                {
                    idapoderado = 0,
                    nombreApoderado = "Pendiente",
                    apellidoApoderado = "Pendiente",
                    dniApoderado = "Pendiente",
                    direccionApoderado = "Pendiente",
                    profesionApoderado = "Pendiente",
                    telefonoApoderado = "Pendiente",
                    idrelacion = -1,
                    idusuario = 0
                };
            }
            ViewBag.idRelacion = new SelectList(db.Relacion, "idrelacion", "descripcion");
            Session["Apoderado"] = apoderado;
            return View();
        }

        public ActionResult PerfilUsuario()
        {
           
            return View();
        }

        public ActionResult Horario()
        {

            usuario = (Usuario)Session["Usuario"];

            if (usuario != null)
            {
                return View();
            }

            return RedirectToAction("Login", "Login");
        }

        public ActionResult AcercaDe()
        {
           
            return View();
        }

        public ActionResult Evaluacion()
        {
            return View();
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