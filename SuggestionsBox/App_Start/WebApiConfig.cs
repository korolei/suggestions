using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace SuggestionsBox
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.MapHttpAttributeRoutes();
            GlobalConfiguration.Configure(x =>
            {
                x.MapHttpAttributeRoutes();
            });

            //Web API routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void Configure(HttpConfiguration config)
        {
            //Formatters
            var jqueryFormatter = config.Formatters.FirstOrDefault(
                x => x.GetType() ==
                     typeof(JQueryMvcFormUrlEncodedFormatter));
            config.Formatters.Remove(
                config.Formatters.FormUrlEncodedFormatter);
            config.Formatters.Remove(jqueryFormatter);
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter> { new StringEnumConverter() },
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            foreach (var formatter in config.Formatters)
            {
                formatter.RequiredMemberSelector =
                    new SuppressedRequiredMemberSelector();

            }
        }
    }

    public class SuppressedRequiredMemberSelector
        : IRequiredMemberSelector
    {
        public bool IsRequiredMember(MemberInfo member)
        {
            return false;
        }
    }
}
