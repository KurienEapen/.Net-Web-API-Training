﻿using FirstWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FirstWebApplication
{
    public static class WebApiConfig
    {
        public static List<BookModel> AllBooks = new List<BookModel>();
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

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
