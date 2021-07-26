using MyServersWebApp.Data;
using MyServersWebApp.MyServersApiSimulatorService;
using MyServersWebApp.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System;
using System.Configuration;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyServersWebApp
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var authInfo = new AuthInfo()
            {
                Username = ConfigurationManager.AppSettings["MyServersApiUsername"],
                Password = ConfigurationManager.AppSettings["MyServersApiPassword"],
            };

            var apiClient = new MyServersApiClient();

            GlobalSettings.authInfo = authInfo;
            GlobalSettings.apiClient = apiClient;

            ConfigureServices();
        }

        private void ConfigureServices()
        {
            GlobalSettings.Container = new Container();

            GlobalSettings.Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            GlobalSettings.Container.Register<IServerDBService, ServerDBService>(Lifestyle.Singleton);
            GlobalSettings.Container.Register<IServerService, ServerService>(Lifestyle.Singleton);
            GlobalSettings.Container.Register<IForwardDnsService, ForwardDnsService>(Lifestyle.Singleton);
            GlobalSettings.Container.Register<IReverseDnsService, ReverseDnsService>(Lifestyle.Singleton);

            GlobalSettings.Container.Verify();
        }
    }
}