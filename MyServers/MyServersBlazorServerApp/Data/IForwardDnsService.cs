using MyServersApiSimulatorService;
using System.Threading.Tasks;

namespace MyServersBlazorServerApp.Data
{
    interface IForwardDnsService
    {
        Task<HostedDomainInfo[]> GetForwardDnsDomains();
    }
}
