using Proyecto_SistemaIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*Para enviar correo Electrónico*/
using System.Net.Mail;
using System.Net;
using System.Threading;
namespace Proyecto_SistemaIntranet.Controllers
{
    public class LoginController : Controller
    {
        SistemaIntranetEntities db = new SistemaIntranetEntities();
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
            
          
                    //Buscamos al Usuario segun el username y password ingresado.
                    var obj_user = (from d in db.Usuario
                                    where d.username == username.Trim() && d.password == password.Trim() && d.estado == "Activo"
                                    select d).FirstOrDefault();
                    if(obj_user == null)
                    {
                        ViewBag.Error = "Usuario y/o Contraseña no existe";
                        return View();
                    }

                    var menuUsuario = (from m in db.usp_user_acceso(obj_user.idrol, obj_user.idusuario) select m);
                    string nombreRol = (from r in db.Rol where r.idrol == obj_user.idrol select r.descripcion).FirstOrDefault();
                    List<usp_user_acceso_Result> Menu = menuUsuario.ToList();
                    Session["Rol"] = nombreRol;
                    Session["Menu"] = Menu;
                    Session["Usuario"] = obj_user;
                
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
            Session["Menu"] = null;
            Session["Rol"] = null;
            Session["Apoderado"] = null;
            return RedirectToAction("Login","Login");
        }

        public ActionResult RecuperaPassword()
        {

            return View();
        }

        [HttpPost]
        public ActionResult RecuperaPassword(string correo)
        {
            var obj_user = (from d in db.Usuario
                            where d.emailUsuario == correo
                            select d).FirstOrDefault();

            string contenido = "<body>" +
                "<h1 style = 'text-align:center;'>¡Recupera tu contraseña!</h1><br><h4>Estimado usuario,</h4><span>" +
                "Le informamos que usted solicitó la recuperación de su contraseña del Sistema Intranet Sigma: </span>"
                + "<h1 style = 'text-align:center;'> Su contraseña es: "+obj_user.password +"</h1>" +
                "<br/><span>Por su seguridad, se recomienda que cambie su contraseña y evite compartirla con desconocidos. </span>" +
                "<br/><h4>Colegio Sigma - 'El aprendizaje nunca se detiene'</h4></body>";


            SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com");

            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            NetworkCredential credential = new NetworkCredential("i201824463@cibertec.edu.pe", "00000");
            smtp.EnableSsl = true;
            smtp.Credentials = credential;
          
           

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("i201824463@cibertec.edu.pe", "Prueba");
            mail.To.Add(new MailAddress(correo));
            mail.Subject = "Colegio SIGMA - Recupera tu Contraseña";
            mail.IsBodyHtml = true;
            mail.Body = contenido;
            try
            {
                //Thread email = new Thread(delegate()
                //{
                    smtp.Send(mail);
                //});

                //email.IsBackground = true;
                //email.Start();
                   

            }catch(Exception ex)
            {
                ex.Message.ToString();
                ViewBag.Error ="Error:" + ex.Message;
                return View();
            }
            
            return View();
        }
    }
}