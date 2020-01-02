using System.Web;
using System.Web.Optimization;

namespace WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Bundling custom scripts
            bundles.Add(new ScriptBundle("~/bundles/lazyloading").Include(
                        "~/Scripts/lazyloading*"));
            bundles.Add(new ScriptBundle("~/bundles/modal").Include(
                        "~/Scripts/modal*"));
            bundles.Add(new ScriptBundle("~/bundles/jquerytimeago").Include(
                        "~/Scripts/jquery.timeago*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css").Include("~/Content/all.css", new CssRewriteUrlTransform()));

        }
    }
}
