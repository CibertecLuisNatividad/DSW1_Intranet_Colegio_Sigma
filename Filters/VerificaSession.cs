using Proyecto_SistemaIntranet.Controllers;
using Proyecto_SistemaIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_SistemaIntranet.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private Usuario objUsuario;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                objUsuario = (Usuario)HttpContext.Current.Session["Usuario"];
                if(objUsuario == null)
                {
                    if(filterContext.Controller is LoginController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Login/Login");
                    }
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }


            
        }
    }
}