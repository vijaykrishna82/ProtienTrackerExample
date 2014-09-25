using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ProtienTrackerMvc.Api;
using ServiceStack;
using ServiceStack.Mvc;

namespace ProtienTrackerMvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            new ProtienTrackerAppHost().Init();
        }

        public class ProtienTrackerAppHost : AppHostBase
        {
            public ProtienTrackerAppHost()
                : base("Protien Tracker Web Services", typeof(HelloService).Assembly)
            {
            }

            public override void Configure(Funq.Container container)
            {
                ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
                SetConfig(new HostConfig {HandlerFactoryPath = "api"});
            }
        }
    }
}