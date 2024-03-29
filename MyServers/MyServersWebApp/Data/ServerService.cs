﻿using MyServersWebApp.MyServersApiSimulatorService;
using MyServersWebApp.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace MyServersWebApp.Data
{
    public class ServerService : IServerService
    {
        private readonly IServerDBService _serverDBService;

        public ServerService(IServerDBService serverDBService)
        {
            _serverDBService = serverDBService;
        }
        
        public async Task<List<Model.ServerInfo>> GetAllServerDetailsAsync()
        {
            List<Model.ServerInfo> serverDetails;

            if(Convert.ToBoolean(ConfigurationManager.AppSettings["AllServerDetailsFromDB"]))
            {
                serverDetails = _serverDBService.Get();
            }
            else
            {
                var apiClientServerDetailsResults = await GlobalSettings.
                                                        apiClient
                                                        .GetAllServerDetailsAsync(GlobalSettings.authInfo);

                var apiClientServerDetailsResultsConverted = apiClientServerDetailsResults
                                                                .ToList()
                                                                .Select(x => new Model.ServerInfo()
                                                                {
                                                                    ServiceID = x.ServiceID,
                                                                    ServiceType = x.ServiceType,
                                                                    PrimaryIP = x.PrimaryIP,
                                                                    Location = x.Location,
                                                                    YourReference = x.YourReference,
                                                                    Status = x.Status,
                                                                    Suspended = x.Suspended,
                                                                })
                                                                .ToList();

                serverDetails = apiClientServerDetailsResultsConverted;
            }

            return serverDetails;
        }

        public async Task<List<CurrentMonitorStatus>> GetServerStatusAsync(string serviceID)
        {
            try
            {
                var serverStatuses = await GlobalSettings.apiClient.GetServerStatusAsync(GlobalSettings.authInfo, serviceID);

                return serverStatuses.ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public Task<ServerInfo> GetServerDetailsAsync(string serviceID)
        {
            try
            {
                return GlobalSettings.apiClient.GetServerDetailsAsync(GlobalSettings.authInfo, serviceID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> SuspendServerAsync(string serviceID, string suspensionReason)
        {
            try
            {
                await GlobalSettings.apiClient.SuspendServerAsync(GlobalSettings.authInfo, serviceID, suspensionReason);
                return string.Empty;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> UnsuspendServerAsync(string serviceID)
        {
            try
            {
                await GlobalSettings.apiClient.UnsuspendServerAsync(GlobalSettings.authInfo, serviceID);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
