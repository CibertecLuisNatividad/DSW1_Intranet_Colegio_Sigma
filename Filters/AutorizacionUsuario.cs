using Proyecto_SistemaIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_SistemaIntranet.Filters
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple = false)]
    public class AutorizacionUsuario : AuthorizeAttribute
    {
        private Usuario oUsuario;
        private SistemaIntranetEntities db = new SistemaIntranetEntities();
        private int idAcceso;

        public AutorizacionUsuario(int idAcceso = 0)
        {
            this.idAcceso = idAcceso;
        }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreMenu = "";
            
            try
            {
                oUsuario = (Usuario)HttpContext.Current.Session["Usuario"];
                var lstMisAccesos = from m in db.Rol_has_Acceso
                                    where m.idrol == oUsuario.idrol
                                    && m.idacceso == idAcceso
                                    select m;
                //var lstMisOperaciones = from m in db.rol_operacion
                //                        where m.idRol == oUsuario.idRol
                //                            && m.idOperacion == idAcceso
                //                        select m;


                if (lstMisAccesos.ToList().Count() == 0)
                {
                    var oAcceso = db.Acceso.Find(idAcceso);
                    int? idacceso = oAcceso.idacceso;
                    nombreMenu = getNombreMenu(idAcceso);
                  //  nombreModulo = getNombreDelModulo(idModulo);
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?acceso=" + nombreMenu + "&msjeErrorExcepcion=");
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?acceso=" + nombreMenu + "&msjeErrorExcepcion=" + ex.Message);
            }
        }

        public string getNombreMenu(int idAcceso)
        {
            var acceso = from o in db.Acceso
                         where o.idacceso == idAcceso
                         select o.nombreAcceso;
          
            String nombreMenu;
            try
            {
                nombreMenu = acceso.First();
            }
            catch (Exception)
            {
                nombreMenu = "";
            }
            return nombreMenu;
        }

        //public string getNombreDelModulo(int? idModulo)
        //{
        //    var modulo = from m in db.modulo
        //                 where m.id == idModulo
        //                 select m.nombre;
        //    String nombreModulo;
        //    try
        //    {
        //        nombreModulo = modulo.First();
        //    }
        //    catch (Exception)
        //    {
        //        nombreModulo = "";
        //    }
        //    return nombreModulo;
        //}
    }
}