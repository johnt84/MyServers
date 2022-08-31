using MyServersWebApp.MyServersApiSimulatorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyServersWebApp.Data
{
    public class ForwardDnsService : IForwardDnsService
    {
        public async Task<List<HostedDomainInfo>> GetForwardDnsDomainsAsync()
        {
            var forwardDnsDomains = await GlobalSettings.apiClient.GetForwardDnsDomainsAsync(GlobalSettings.authInfo);

            return forwardDnsDomains.ToList();
        }

        public List<HostedDomainInfo> GetForwardDnsDomains(CancellationToken cancellationToken)
        {
            var forwardDnsDomains = GlobalSettings.apiClient.GetForwardDnsDomains(GlobalSettings.authInfo);

            //Task.Delay(10000000).Wait(cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            return forwardDnsDomains.ToList();
        }
    }
}