using System.Web;
using System.Web.Optimization;

namespace IOTManagerSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-js").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-css").Include(
                      "~/Content/bootstrap-theme.css",
                      "~/Content/bootstrap-theme.min.css",
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
                        "~/Content/kendo/2018.2.620/kendo.default.mobile.min.css",
                        "~/Content/kendo/2018.2.620/kendo.default.min.css",
                        "~/Content/kendo/2018.2.620/kendo.rtl.min.css",
                        "~/Content/kendo/2018.2.620/kendo.common.min.css",
                        "~/Content/kendo/2018.2.620/kendo.mobile.all.min.css",
                        "~/Content/kendo/2018.2.620/kendo.material.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/kendo/2018.2.620/kendo.all.min.js",
                        "~/Scripts/kendo/2018.2.620/kendo.aspnetmvc.min.js"));
        }
    }
}
