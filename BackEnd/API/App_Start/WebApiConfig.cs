using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
namespace API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));
            //CORS config  
            config.EnableCors(new EnableCorsAttribute("http://localhost:4200", "*", "*"));

            //var cors = new EnableCorsAttribute("*", "*", "*"); //origins,headers,methods  
            //config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
