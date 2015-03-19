using System.Web;
using System.Web.Optimization;

namespace Saleular
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Styles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap-yeti.css",
                    "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/home_index").Include(
                    "~/Content/custom/home_index.css"));

            bundles.Add(new StyleBundle("~/Content/home_home").Include(
                    "~/Content/custom/home_home.css"));

            bundles.Add(new StyleBundle("~/Content/home_questions").Include(
                    "~/Content/custom/home_questions.css"));

            bundles.Add(new StyleBundle("~/Content/home_companyinfo").Include(
                    "~/Content/custom/home_companyinfo.css"));

            bundles.Add(new StyleBundle("~/Content/phone_offer").Include(
                    "~/Content/custom/phone_offer.css"));

            bundles.Add(new StyleBundle("~/Content/phone_ship").Include(
                    "~/Content/custom/phone_ship.css"));

            bundles.Add(new StyleBundle("~/Content/phone_sellphone").Include(
                   "~/Content/custom/phone_sellphone.css"));

            // Scripts
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/Scripts/modernizr").Include(
                    "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                    "~/Scripts/jquery/jquery-{version}.js",                    
                    "~/Scripts/bootstrap/bootstrap.js",
                    "~/Scripts/respond.js",
                    "~/Scripts/site.js"));

            bundles.Add(new ScriptBundle("~/Scripts/validate").Include(
                        "~/Scripts/jquery/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/Scripts/validation").Include(                    
                    "~/Scripts/jquery/jquery.validate.js",
                    "~/Scripts/jquery/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/Scripts/home_index").Include(
                    "~/Scripts/custom/home_index.js"));

            bundles.Add(new ScriptBundle("~/Scripts/home_home").Include(
                    "~/Scripts/custom/home_home.js"));

            bundles.Add(new ScriptBundle("~/Scripts/home_questions").Include(
                    "~/Scripts/custom/home_questions.js"));

            bundles.Add(new ScriptBundle("~/Scripts/home_companyinfo").Include(
                    "~/Scripts/custom/home_companyinfo.js"));

            bundles.Add(new ScriptBundle("~/Scripts/phone_offer").Include(
                    "~/Scripts/custom/phone_offer.js"));

            bundles.Add(new ScriptBundle("~/Scripts/phone_ship").Include(
                   "~/Scripts/custom/phone_ship.js"));

            bundles.Add(new ScriptBundle("~/Scripts/request_gadgets").Include(
                    "~/Scripts/custom/request_gadgets.js"));

            bundles.Add(new ScriptBundle("~/Scripts/phone_pricelist").Include(
                    "~/Scripts/custom/phone_pricelist.js"));

            bundles.Add(new ScriptBundle("~/Scripts/phone_sellphone").Include(
                    "~/Scripts/custom/phone_sellphone.js"));

            bundles.Add(new ScriptBundle("~/Scripts/angularjs").Include(
                    "~/Scripts/angular/angular.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
