using MyServersApiSimulatorService;
using System;
using System.Threading.Tasks;

namespace MyServersBlazorServerApp.Data
{
    public class ServersService : IServerService
    {
        MyServersApiClient apiClient = new MyServersApiClient();

        AuthInfo authInfo = new AuthInfo()
        {
            Username = "",
            Password = "",
        };

        public async Task<ServerInfo[]> GetAllServerDetails()
        {
            return await apiClient.GetAllServerDetailsAsync(authInfo);
        }

        public async Task<CurrentMonitorStatus[]> GetServerStatus(string serviceID)
        {
            try
            {
                return await apiClient.GetServerStatusAsync(authInfo, serviceID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ServerInfo> GetServerDetails(string serviceID)
        {
            try
            {
                return await apiClient.GetServerDetailsAsync(authInfo, serviceID);
            }
            catch (Exception ex)
            {
                return new ServerInfo();
            }
        }
    }
}
