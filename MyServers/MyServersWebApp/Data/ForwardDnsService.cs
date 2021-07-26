using MyServersWebApp.MyServersApiSimulatorService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyServersWebApp.Data
{
    public class ForwardDnsService : IForwardDnsService
    {
        public async Task<List<HostedDomainInfo>> GetForwardDnsDomains()
        {
            var forwardDnsDomains = await GlobalSettings.apiClient.GetForwardDnsDomainsAsync(GlobalSettings.authInfo);

            return forwardDnsDomains.ToList();
        }
    }
}