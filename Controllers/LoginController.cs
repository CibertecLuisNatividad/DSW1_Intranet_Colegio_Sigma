using Proyecto_SistemaIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_SistemaIntranet.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            try
            {
            
                using(Models.SistemaIntranetEntities db = new Models.SistemaIntranetEntities())
                {
                    //Buscamos al Usuario segun el username y password ingresado.
                    var obj_user = (from d in db.Usuario
                                    where d.username == username.Trim() && d.password == password.Trim()
                                    select d).FirstOrDefault();
                    if(obj_user == null)
                    {
                        ViewBag.Error = "Usuario y/o Contraseña no existe";
                        return View();
                    }
                   // Usuario user = obj_user;
                   // //Buscamos los accesos que tiene el usuario
                   // //var menuUsuario = (from m in db.usp_Usuario_Acceso(obj_user.idrol) select m);
                   // var menuUsuario = db.usp_Usuario_Acceso(user.idrol).ToList();
                   // ViewBag.menu = menuUsuario;
                   // //List<Menu> listaMenu =(List<Menu>) menuUsuario;
                   //// Session["Menu"] = listaMenu;
                    Session["Usuario"] = obj_user;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

           
            return RedirectToAction("Principal", "Dashboard");
        }

        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Login","Login");
        }


    }
}