﻿using System.Web;
using System.Web.Optimization;

namespace StateTemplateV5Beta
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/DataTables").Include(
                     "~/Content/StateTemplate/DataTables-1.10.16/js/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/stateTemplateLibJs").Include(
                     "~/Content/StateTemplate/js/libs/jquery-3.2.1.min.js", "~/Content/StateTemplate/js/libs/modernizr-2.0.6.min.js",
                     "~/Content/StateTemplate/js/libs/modernizr-extra.min.js",
                     "~/Content/StateTemplate/js/libs/jquery.dataTables.min.js",
                     "~/Content/StateTemplate/js/libs/jquery.dataTables.rowReorder.min.js",
                     "~/Content/StateTemplate/js/libs/jquery.dataTables.responsive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/stateTemplateJs").Include(
                     "~/Content/StateTemplate/js/cagov.core.js",
                     "~/Content/StateTemplate/js/search.js"));

            bundles.Add(new StyleBundle("~/Content/stateTemplateCss").Include(
                      "~/Content/StateTemplate/css/cagov.core.css",
                      "~/Content/StateTemplate/css/colorscheme-oceanside.css",
                      "~/Content/StateTemplate/css/bootstrap.min.css",
                      "~/Content/StateTemplate/css/rowReorder.dataTables.min.css",
                      "~/Content/StateTemplate/css/responsive.dataTables.min.css",
                      "~/Content/StateTemplate/DataTables-1.10.16/css/jquery.dataTables.min.css"));
        }
    }
}
