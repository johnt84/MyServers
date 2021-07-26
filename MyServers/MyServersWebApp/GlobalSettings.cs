using MyServersWebApp.MyServersApiSimulatorService;
using SimpleInjector;
using System.Configuration;
using System.Data.SqlClient;

namespace MyServersWebApp
{
    public static class GlobalSettings
    {
        public static AuthInfo authInfo;
        public static MyServersApiClient apiClient;
        public static SqlConnection MyServersDBConnection => new SqlConnection(ConfigurationManager
                                                                    .ConnectionStrings["MyServersDBConnection"]
                                                                    .ConnectionString);
        public static Container Container;
    }
}