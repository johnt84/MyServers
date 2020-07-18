using MyServersApiSimulatorService;
using System.Threading.Tasks;

namespace MyServersBlazorServerApp.Data
{
    public class ForwardDnsService : IForwardDnsService
    {
        MyServersApiClient apiClient = new MyServersApiClient();

        AuthInfo authInfo = new AuthInfo()
        {
            Username = "",
            Password = "",
        };

        public async Task<HostedDomainInfo[]> GetForwardDnsDomains()
        {
            return await apiClient.GetForwardDnsDomainsAsync(authInfo);
        }
    }
}
