using System.Web;
using System.Web.Optimization;

namespace TutorApplication
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
          

             bundles.Add(new ScriptBundle("~/assets/js").Include(
                        "~/assets/js/jquery.js", "~/assets/js/bootstrap.js", "~/calenderscipts/jquery-ui-1.8.20.min.js", "~/Scripts/jquery.validate.unobtrusive.min.js","~/Scripts/jquery.unobtrusive-ajax.min.js", "~/Scripts/jquery.validate.min.js", "~/assets/js/jquery.easing-1.3.min.js", "~/assets/js/jquery.scrollTo-1.4.3.1-min.js", "~/assets/js/shop.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/assets/css").Include("~/assets/css/bootstrap.css", "~/style.css"));

            
        }
    }
}