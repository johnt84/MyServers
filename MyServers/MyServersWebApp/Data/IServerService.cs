using MyServersWebApp.MyServersApiSimulatorService;
using System.Collections.Generic;

namespace MyServersWebApp.Data
{
    interface IServerService
    {
        List<ServerInfo> GetAllServerDetails();
        List<CurrentMonitorStatus> GetServerStatus(string serviceID);
        ServerInfo GetServerDetails(string serviceID);
        string SuspendServer(string serviceID, string suspensionReason);
        string UnsuspendServer(string serviceID);
    }
}
