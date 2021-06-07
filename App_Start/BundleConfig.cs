using System.Web;
using System.Web.Optimization;

namespace Proyecto_SistemaIntranet
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //Solo CSS
            bundles.Add(new StyleBundle("~/assets/css").Include(
                      "~/assets/css/default/app.min.css",
                      "~/Content/site.css"));
            //Solo JS
            bundles.Add(new StyleBundle("~/assets/js").Include(
                     "~/assets/js/app.min.js",
                     "~/assets/js/theme/default.min.js",
                     "~/assets/js/demo/dashboard.js"));

            //Pugins con CSS
            bundles.Add(new StyleBundle("~/assets/plugins/css").Include(
                     "~/assets/plugins/datatables.net-bs4/css/dataTables.bootstrap4.min.css",
                     "~/assets/plugins/datatables.net-responsive-bs4/css/responsive.bootstrap4.min.css"));

            //Plugins con JS
            bundles.Add(new StyleBundle("~/assets/plugins/jss").Include(
                     "~/assets/plugins/gritter/js/jquery.gritter.js"));

        }
    }
}
