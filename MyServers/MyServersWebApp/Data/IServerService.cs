using MyServersWebApp.MyServersApiSimulatorService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyServersWebApp.Data
{
    public interface IServerService
    {
        Task<List<Model.ServerInfo>> GetAllServerDetails();
        Task<List<CurrentMonitorStatus>> GetServerStatus(string serviceID);
        ServerInfo GetServerDetails(string serviceID);
        Task<string> SuspendServer(string serviceID, string suspensionReason);
        Task<string> UnsuspendServer(string serviceID);
    }
}
