using MyServersApiSimulatorService;
using System.Threading.Tasks;

namespace MyServersBlazorServerApp.Data
{
    public class ReverseDnsService : IReverseDnsService
    {
        private readonly MyServersApiClient _apiClient;

        public ReverseDnsService(MyServersApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ReverseDnsEntry[]> GetReverseDnsEntriesAsync()
        {
            return await _apiClient.GetReverseDnsEntriesAsync(GlobalSettings.authInfo);
        }
    }
}
