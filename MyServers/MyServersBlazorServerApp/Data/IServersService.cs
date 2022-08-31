using MyServersApiSimulatorService;
using System.Threading.Tasks;

namespace MyServersBlazorServerApp.Data
{
    interface IServerService
    {
        Task<ServerInfo[]> GetAllServerDetailsAsync();
        Task<CurrentMonitorStatus[]> GetServerStatusAsync(string serviceID);
        Task<ServerInfo> GetServerDetailsAsync(string serviceID);
    }
}
