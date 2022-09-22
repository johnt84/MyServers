using MyServersApiSimulatorService;
using System;
using System.Threading.Tasks;

namespace MyServersBlazorServerApp.Data
{
    public class ServerService : IServerService
    {
        private readonly MyServersApiClient _apiClient;

        public ServerService(MyServersApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ServerInfo[]> GetAllServerDetailsAsync()
        {
            return await _apiClient.GetAllServerDetailsAsync(GlobalSettings.authInfo);
        }

        public async Task<CurrentMonitorStatus[]> GetServerStatusAsync(string serviceID)
        {
            try
            {
                return await _apiClient.GetServerStatusAsync(GlobalSettings.authInfo, serviceID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ServerInfo> GetServerDetailsAsync(string serviceID)
        {
            try
            {
                return await _apiClient.GetServerDetailsAsync(GlobalSettings.authInfo, serviceID);
            }
            catch (Exception ex)
            {
                return new ServerInfo();
            }
        }


        public async Task<string> SuspendServerAsync(string serviceID, string suspensionReason)
        {
            try
            {
                await _apiClient.SuspendServerAsync(GlobalSettings.authInfo, serviceID, suspensionReason);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> UnsuspendServerAsync(string serviceID)
        {
            try
            {
                await _apiClient.UnsuspendServerAsync(GlobalSettings.authInfo, serviceID);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
