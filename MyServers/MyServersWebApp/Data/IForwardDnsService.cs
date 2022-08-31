using MyServersWebApp.MyServersApiSimulatorService;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyServersWebApp.Data
{
    public interface IForwardDnsService
    {
        Task<List<HostedDomainInfo>> GetForwardDnsDomainsAsync();
        List<HostedDomainInfo> GetForwardDnsDomains(CancellationToken cancellationToken);
    }
}
