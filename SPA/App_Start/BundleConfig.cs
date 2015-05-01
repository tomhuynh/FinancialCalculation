using System.Web.Optimization;

namespace SPA
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/lib/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.validation.js"));
                
            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                "~/Scripts/lib/angular/angular.js",
                "~/Scripts/lib/angular/angular-route.js",
                "~/Scripts/lib/angular/angular-sanitize.js",
                "~/Scripts/lib/utils/lodash.underscore.js",
                "~/Scripts/lib/bootstrap/bootstrap.js",
                "~/Scripts/angular/alert/alertCtrl.js",
                "~/Scripts/angular/alert/alert-service.js",
                "~/Scripts/angular/alert/my-alert.js",
                "~/Scripts/angular/common/routes.js"
                ).IncludeDirectory("~/Scripts/angular", "*.js", true));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/lib/bootstrap/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                 "~/css/bootstrap.css",
                 "~/css/Site.css"));
        }
    }
}
