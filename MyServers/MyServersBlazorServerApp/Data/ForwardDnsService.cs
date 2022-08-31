using MyServersApiSimulatorService;
using System.Threading.Tasks;

namespace MyServersBlazorServerApp.Data
{
    public class ForwardDnsService : IForwardDnsService
    {
        private readonly MyServersApiClient _apiClient;

        public ForwardDnsService(MyServersApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<HostedDomainInfo[]> GetForwardDnsDomainsAsync()
        {
            return await _apiClient.GetForwardDnsDomainsAsync(GlobalSettings.authInfo);
        }
    }
}
