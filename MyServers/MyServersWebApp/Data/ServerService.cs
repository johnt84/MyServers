using MyServersWebApp.MyServersApiSimulatorService;
using MyServersWebApp.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace MyServersWebApp.Data
{
    public class ServerService : IServerService
    {
        private ServerDBService serverDBService = new ServerDBService();
        
        public List<Model.ServerInfo> GetAllServerDetails()
        {
            List<Model.ServerInfo> serverDetails;

            if(Convert.ToBoolean(ConfigurationManager.AppSettings["AllServerDetailsFromDB"]))
            {
                serverDetails = serverDBService.Get();
            }
            else
            {
                var apiClientServerDetails = GlobalSettings.
                                            apiClient.GetAllServerDetails(GlobalSettings.authInfo)
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

                serverDetails = apiClientServerDetails;
            }

            return serverDetails;
        }

        public List<CurrentMonitorStatus> GetServerStatus(string serviceID)
        {
            try
            {
                return GlobalSettings.apiClient.GetServerStatus(GlobalSettings.authInfo, serviceID).ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public ServerInfo GetServerDetails(string serviceID)
        {
            try
            {
                return GlobalSettings.apiClient.GetServerDetails(GlobalSettings.authInfo, serviceID);
            }
            catch (Exception ex)
            {
                return new ServerInfo();
            }
        }

        public string SuspendServer(string serviceID, string suspensionReason)
        {
            try
            {
                GlobalSettings.apiClient.SuspendServer(GlobalSettings.authInfo, serviceID, suspensionReason);
                return string.Empty;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string UnsuspendServer(string serviceID)
        {
            try
            {
                GlobalSettings.apiClient.UnsuspendServer(GlobalSettings.authInfo, serviceID);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
