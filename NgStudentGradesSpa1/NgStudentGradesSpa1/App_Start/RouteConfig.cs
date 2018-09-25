﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NgStudentGradesSpa1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default1",
                url: "",
                defaults: new { controller = "Student", action = "StudentHome", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default3",
                url: "SearchStudent",
                defaults: new { controller = "Student", action = "SearchStudent", id = UrlParameter.Optional }
            );
           
            routes.MapRoute(
                name: "Default2",
                url: "NewStudentScore",
                defaults: new { controller = "Student", action = "StudentsGrades", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
