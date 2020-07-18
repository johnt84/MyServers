using MyServersApiSimulatorService;
using System.Threading.Tasks;

namespace MyServersBlazorServerApp.Data
{
    public class ReverseDnsService : IReverseDnsService
    {
        MyServersApiClient apiClient = new MyServersApiClient();

        AuthInfo authInfo = new AuthInfo()
        {
            Username = "",
            Password = "",
        };

        public async Task<ReverseDnsEntry[]> GetReverseDnsEntries()
        {
            return await apiClient.GetReverseDnsEntriesAsync(authInfo);
        }
    }
}
