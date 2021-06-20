using Proyecto_SistemaIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_SistemaIntranet.Controllers
{
    public class UserController : Controller
    {
        SistemaIntranetEntities bd = new SistemaIntranetEntities();
        Usuario usuario;
        /*
         * En esta vista se mostraran la lista de horarios de los alumnos segun su grado
         * Aclaraciones: Todos los usuarios del mismo grado tienen el mismo horario de clases
         */
        public ActionResult ListaHorarioAlumno()
        {
            return View();
        }

        /*
         * Se visualizan las cursos por grado de su matricula
         */
        public ActionResult CursosxMatricula()
        {
            return View();
        }

        /*
         * Se visualizan las calificaciones de los alumnos
         * segun su curso
         */
        public ActionResult CalificacionesAlumno(int? idcurso)
        {
            usuario = (Usuario)Session["Usuario"];

            if(usuario != null)
            {
                ViewBag.cursos = new SelectList(bd.Curso.ToList(),"idcurso","nombreCurso", idcurso);

                var calificacion = from ca
                                   in bd.Calificacion
                                   where ca.idusuario == usuario.idusuario && ca.Evaluacion.Curso.idcurso == idcurso
                                   select ca;

                // Listado segun el curso
                return View(calificacion.ToList());
            }
            return View();
        }
    }
}