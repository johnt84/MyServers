using MyServersApiSimulatorService;
using System.Threading.Tasks;

namespace MyServersBlazorServerApp.Data
{
    interface IServerService
    {
        Task<ServerInfo[]> GetAllServerDetails();
        Task<CurrentMonitorStatus[]> GetServerStatus(string serviceID);
        Task<ServerInfo> GetServerDetails(string serviceID);
    }
}
