using ProjectLogic.BLL;
using ProjectLogic.DAL;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace Administrator
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

            // configuration para inyectar por dependecia con Unity
            container = new UnityContainer();
            container.RegisterType<DbSqlConnetion>();
            container.RegisterType<ProductsBLL>();
            container.RegisterType<ProductsDAL>();
            container.RegisterType<UsersDAL>();
            container.RegisterType<UsersBLL>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
