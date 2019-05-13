using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MvcUserRoles
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //var settings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            //settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //settings.Formatting = Formatting.Indented;
            //config.Routes.MapHttpRoute(
            //     name: "2Api",
            //     routeTemplate: "Home/api/{controller}/{id}",
            //     defaults: new { id = RouteParameter.Optional }
            // );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
