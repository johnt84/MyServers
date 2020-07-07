using MyServersWebApp.MyServersApiSimulatorService;
using System.Collections.Generic;
using System.Linq;

namespace MyServersWebApp.Data
{
    public class ServerService : IServerService
    {
        public List<ServerInfo> GetAllServerDetails()
        {
            return GlobalSettings.apiClient.GetAllServerDetails(GlobalSettings.authInfo).ToList();
        }

        public List<CurrentMonitorStatus> GetServerStatus(string serviceID)
        {
            return GlobalSettings.apiClient.GetServerStatus(GlobalSettings.authInfo, serviceID).ToList();
        }

        public ServerInfo GetServerDetails(string serviceID)
        {
            return GlobalSettings.apiClient.GetServerDetails(GlobalSettings.authInfo, serviceID);
        }
    }
}
