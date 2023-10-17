using System.Web;
using System.Web.Optimization;

namespace PS.HireRocks.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.min.js",
                        "~/Scripts/jquery-ui-1.11.2.min.js",
                        "~/Scripts/MetroJs.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/jquery.form.min.js",
                        "~/Scripts/moment.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/homePage").Include(
                    "~/Scripts/HomePageScript.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                      "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap-datepicker.min.js",
                      "~/Scripts/respond.min.js"));
          

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/datepicker.min.css",
                      "~/Content/site.css",                     
                      "~/Content/MetroJs.min.css"));
            bundles.Add(new StyleBundle("~/Content/homePageCss").Include(
                 "~/Content/Custom.css",
                 "~/Content/MetroJs.min.css"));
              

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
                      "~/Content/kendo/kendo.common-bootstrap.min.css",
                      "~/Content/kendo/kendo.bootstrap.min.css"));  

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                      "~/Scripts/kendo/kendo.all.min.js",
                      "~/Scripts/kendo/kendo.aspnetmvc.min.js"));
            bundles.UseCdn = true;
            bundles.Add(new ScriptBundle("~/bundles/Particles",
                "https://cldup.com/S6Ptkwu_qA.js").Include(
                "~/Scripts/jquery-{version}.js"));
          
            BundleTable.EnableOptimizations = true;
            bundles.IgnoreList.Clear();
        }
    }
}
