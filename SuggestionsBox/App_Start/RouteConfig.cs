using System.Web.Mvc;
using System.Web.Routing;

namespace SuggestionsBox
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RouteTable.Routes.Ignore("api/{*anything}");
            RouteTable.Routes.MapPageRoute("AnythingNonApi", "{*url}", "~/wwwroot/index.html");
        }
    }
}
