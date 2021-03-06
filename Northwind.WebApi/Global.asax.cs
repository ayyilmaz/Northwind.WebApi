﻿using System;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Northwind.WebApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
//            GlobalConfiguration.Configuration.Formatters.RemoveAt(0);


        }

        protected void Application_Error(object sender, Exception exception)
        {
            new LogEvent(exception.Message).Raise();
        }
    }
}