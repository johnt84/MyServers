using MyServersWebApp.MyServersApiSimulatorService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyServersWebApp.Data
{
    public interface IServerService
    {
        Task<List<Model.ServerInfo>> GetAllServerDetailsAsync();
        Task<List<CurrentMonitorStatus>> GetServerStatusAsync(string serviceID);
        Task<ServerInfo> GetServerDetailsAsync(string serviceID);
        Task<string> SuspendServerAsync(string serviceID, string suspensionReason);
        Task<string> UnsuspendServerAsync(string serviceID);
    }
}
