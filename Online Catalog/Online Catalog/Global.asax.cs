﻿using ProjectLogic.BLL;
using ProjectLogic.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace Online_Catalog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IUnityContainer container;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // configuracion inyeccion
            container = new UnityContainer();
            container.RegisterType<DbSqlConnetion>();
            container.RegisterType<ProductsBLL>();
            container.RegisterType<ProductsDAL>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
