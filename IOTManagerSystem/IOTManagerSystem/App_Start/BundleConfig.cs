﻿using System.Web;
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


            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                                 "~/Scripts/kendo/kendo.all.min.js",
                                  "~/Scripts/kendo/kendo.timezones.min.js", // uncomment if using the Scheduler
                                 "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
               "~/Content/kendo/kendo.common-bootstrap.min.css",
               "~/Content/kendo/kendo.bootstrap.min.css"));

            //bundles.IgnoreList.Clear();
        }
    }
}
