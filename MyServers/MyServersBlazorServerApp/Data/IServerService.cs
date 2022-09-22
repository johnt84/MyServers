using MyServersApiSimulatorService;
using System.Threading.Tasks;

namespace MyServersBlazorServerApp.Data
{
    interface IServerService
    {
        Task<ServerInfo[]> GetAllServerDetailsAsync();
        Task<CurrentMonitorStatus[]> GetServerStatusAsync(string serviceID);
        Task<ServerInfo> GetServerDetailsAsync(string serviceID);
        Task<string> SuspendServerAsync(string serviceID, string suspensionReason);
        Task<string> UnsuspendServerAsync(string serviceID);
    }
}
