using Proyecto_SistemaIntranet.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_SistemaIntranet.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

            if (usuario != null)
            {
                return View();
            }

            return RedirectToAction("Login", "Login");

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

          

            ViewBag.idRelacion = new SelectList(db.Relacion, "idrelacion", "descripcion",ap.idrelacion);
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
                Matricula matricula = (from m in db.Matricula where m.idusuario == usuario.idusuario select m).FirstOrDefault();
                var gs = (from g in db.Grado_Has_Seccion
                          where g.idgrado_seccion == matricula.idgrado_seccion
                          select g).FirstOrDefault();
                var hor = (from h in db.Horario where h.idgrado == gs.idgrado && h.idseccion == gs.idseccion
                           select h).ToList();
                
                //List<Carga_Academica> listCA = new List<Carga_Academica>();
                //foreach (var lista in hor)
                //{
                //    listCA.Add((from D in db.Carga_Academica
                //                where D.idcurso == lista.idcurso
                //                select D).FirstOrDefault());                 

                //}
                //ViewBag.DocentexCurso = listCA;
   

                ViewBag.Horario = hor;
                


                return View();
            }

            return RedirectToAction("Login", "Login");
        }

        public ActionResult GestionarUsuarios()
        {
            usuario = (Usuario)Session["Usuario"];

            if (usuario != null)
            {
                return View();
            }

            return RedirectToAction("Login", "Login");
        }

        public ActionResult Matricula()
        {
            usuario = (Usuario)Session["Usuario"];

            if (usuario != null)
            {

                ViewBag.idrelacion = new SelectList(db.Relacion, "idrelacion", "descripcion");
                ViewBag.idgrado = new SelectList(db.Grado, "idgrado", "nombreGrado");
                ViewBag.idseccion = new SelectList(db.Seccion, "idseccion", "nombreSeccion");


                return View();
            }

            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Matricula([Bind(Include = "nombreUsuario,apellidoUsuario,dniUsuario,fechaNacUsuario," +
            "direccionUsuario,telefonoUsuario,username,password,rutaImagen,emailUsuario,estado")] Usuario user,
            [Bind(Include = "nombreApoderado,apellidoApoderado,dniApoderado,direccionApoderado,profesionApoderado,telefonoApoderado,idrelacion,emailApoderado")] Apoderado apo,
            [Bind(Include = "idgrado,idseccion,vacante_total,vacante_disponible")] Grado_Has_Seccion ghs)
        {
            //En primer lugar verificamos que haya vacantes disponibles 
            if (ghs.vacante_disponible > 0)
            {
                /*Buscamos el idgrado_seccion*/
                var ma = (from m in db.Grado_Has_Seccion
                          where m.idgrado == ghs.idgrado && m.idseccion == ghs.idseccion
                          select m).FirstOrDefault();

                //Actualizamos Vacantes
                Grado_Has_Seccion gr = new Grado_Has_Seccion()
                {
                    idgrado_seccion = ma.idgrado_seccion,
                    idgrado = ghs.idgrado,
                    idseccion = ghs.idseccion,
                    vacante_total = ghs.vacante_total,
                    vacante_disponible = ghs.vacante_disponible - 1
                };
                db.Set<Grado_Has_Seccion>().AddOrUpdate(gr);
                //db.Entry(gr).State = EntityState.Modified;
                db.SaveChanges();

                //Registro de Usuario (Alumno)
                user.idrol = 2;
                db.Usuario.Add(user);
                db.SaveChanges();

                //Registro de Apoderado del Alumno
                apo.idusuario = user.idusuario;
                db.Apoderado.Add(apo);
                db.SaveChanges();

                //************Registro de Matricula***********/
                ///*Buscamos el idgrado_seccion*/
                //var ma = from m in db.Grado_Has_Seccion
                //         where m.idgrado == ghs.idgrado && m.idseccion == ghs.idseccion
                //         select m.idgrado_seccion;
                ///*Lo convertimos en int*/
                //int idgs = Convert.ToInt32(ma.);
                //Almacenamos los valores en un nuevo objeto de Matricula
                Matricula matricula = new Matricula()
                {
                    idgrado_seccion = ma.idgrado_seccion,
                    idusuario = user.idusuario
                };

                //Guardamos cambios
                db.Matricula.Add(matricula);
                db.SaveChanges();

                ViewBag.Mensaje = "Matrícula Exitosa del Alumno";
                ViewBag.idrelacion = new SelectList(db.Relacion, "idrelacion", "descripcion");
                ViewBag.idgrado = new SelectList(db.Grado, "idgrado", "nombreGrado");
                ViewBag.idseccion = new SelectList(db.Seccion, "idseccion", "nombreSeccion");
                return View();
            }
            else
            {
                ViewBag.idrelacion = new SelectList(db.Relacion, "idrelacion", "descripcion");
                ViewBag.idgrado = new SelectList(db.Grado, "idgrado", "nombreGrado");
                ViewBag.idseccion = new SelectList(db.Seccion, "idseccion", "nombreSeccion");
                ViewBag.Mensaje = "No Existen Vacantes Disponibles. No se puede Matricular al Alumno";
                return View();
            }
       
        }


        public JsonResult getVacantes(int idgrado, int idseccion)
        {
            //Este codigo sirve para evitar el loop infinito por tener referencias ciclicas
            //de este objeto
            db.Configuration.ProxyCreationEnabled = false;

            var vacantes = (from v in db.Grado_Has_Seccion
                            where v.idgrado == idgrado && v.idseccion == idseccion
                            select v).FirstOrDefault();
    
            return Json(vacantes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AcercaDe()
        {
           
            return View();
        }

       


        public ActionResult Evaluacion()
        {
            usuario = (Usuario)Session["Usuario"];

            if (usuario.idrol == 2)
            {
                return RedirectToAction("EvaluacionAlumno", "Dashboard");
            }
            return RedirectToAction("EvaluacionDocente", "Dashboard");
        }

        public ActionResult EvaluacionAlumno()
        {
            usuario = (Usuario)Session["Usuario"];

            if(usuario!= null)
            {

                var Ma = (from M in db.Matricula where M.idusuario == usuario.idusuario
                          select M).FirstOrDefault();
                var Ev = (from E in db.Evaluacion
                          where E.idgrado_seccion == Ma.idgrado_seccion
                          select E).ToList();

                ViewBag.Evaluacion = Ev;

                return View();
            }
            return View();
        }

        public ActionResult DetalleEvaluacion(int id)
        {
            usuario = (Usuario)Session["Usuario"];

            if (usuario != null)
            {
                Evaluacion Ev = (from E in db.Evaluacion
                          where E.idevaluacion == id
                          select E).FirstOrDefault();

                ViewBag.Evaluacion = Ev;
                return View();

            }
            return RedirectToAction("EvaluacionAlumno", "Dashboard");
        }

        public ActionResult ConsultaDocente()
        {
            usuario = (Usuario)Session["Usuario"];

            if (usuario != null)
            {
                return View();
            }

            return RedirectToAction("Login", "Login");
        }



    }
}