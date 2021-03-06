﻿using MyServersApiSimulatorService;
using System;
using System.Threading.Tasks;

namespace MyServersBlazorServerApp.Data
{
    public class ServersService : IServerService
    {
        private readonly MyServersApiClient _apiClient;

        public ServersService(MyServersApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ServerInfo[]> GetAllServerDetails()
        {
            return await _apiClient.GetAllServerDetailsAsync(GlobalSettings.authInfo);
        }

        public async Task<CurrentMonitorStatus[]> GetServerStatus(string serviceID)
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

        public async Task<ServerInfo> GetServerDetails(string serviceID)
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
    }
}
