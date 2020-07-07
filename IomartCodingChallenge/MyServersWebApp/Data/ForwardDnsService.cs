using MyServersWebApp.MyServersApiSimulatorService;
using System.Collections.Generic;
using System.Linq;

namespace MyServersWebApp.Data
{
    public class ForwardDnsService : IForwardDnsService
    {
        public List<HostedDomainInfo> GetForwardDnsDomains()
        {
            return GlobalSettings.apiClient.GetForwardDnsDomains(GlobalSettings.authInfo).ToList();
        }
    }
}