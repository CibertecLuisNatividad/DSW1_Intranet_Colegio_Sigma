using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_SistemaIntranet.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [HttpGet]
        public ActionResult UnauthorizedOperation(String acceso, String msjeErrorExcepcion)
        {
            ViewBag.acceso = acceso;
            ViewBag.msjeErrorExcepcion = msjeErrorExcepcion;
            return View();
        }
    }
}