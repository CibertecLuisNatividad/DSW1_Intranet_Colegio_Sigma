using System.Web;
using System.Web.Mvc;

namespace Proyecto_SistemaIntranet
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filters.VerificaSession());
        }
    }
}
