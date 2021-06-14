using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_SistemaIntranet.Controllers
{
    public class UserController : Controller
    {
        // GET: User

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
         * segun su curso y estado
         */
        public ActionResult CalificacionesAlumno()
        {
            return View();
        }
    }
}