using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace VentasJHJ.API._2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //enablecors
            config.Enabl eCors(new EnableCorsAttribute("https://localhost:44395",headers: "*",methods: "*"));
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
