using MyServersWebApp.MyServersApiSimulatorService;
using System.Collections.Generic;

namespace MyServersWebApp.Data
{
    public interface IForwardDnsService
    {
        List<HostedDomainInfo> GetForwardDnsDomains();
    }
}
