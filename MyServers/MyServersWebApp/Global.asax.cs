using MyServersWebApp.MyServersApiSimulatorService;
using System;
using System.Configuration;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyServersWebApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
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
        }
    }
}