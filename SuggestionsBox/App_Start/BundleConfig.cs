using System.Web.Optimization;

namespace SuggestionsBox
{
    public static class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/inline").Include(
                        "~/wwwroot/inline.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                        "~/wwwroot/main.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/polyfills").Include(
                        "~/wwwroot/polyfills.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/wwwroot/assets/Scripts/bootstrap.js",
                      "~/wwwroot/assets/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/wwwroot/assets/css").Include(
                      "~/wwwroot/assets/bootstrap.css",
                      "~/wwwroot/assets/site.css",
                    "~/wwwroot/styles.bundle.css"));
        }
    }
}
