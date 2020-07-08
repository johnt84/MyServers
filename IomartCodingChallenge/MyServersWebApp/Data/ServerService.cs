using MyServersWebApp.MyServersApiSimulatorService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyServersWebApp.Data
{
    public class ServerService : IServerService
    {
        public List<ServerInfo> GetAllServerDetails()
        {
            return GlobalSettings.apiClient.GetAllServerDetails(GlobalSettings.authInfo).ToList();
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
