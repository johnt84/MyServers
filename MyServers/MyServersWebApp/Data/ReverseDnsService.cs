using MyServersWebApp.MyServersApiSimulatorService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyServersWebApp.Data
{
    public class ReverseDnsService : IReverseDnsService
    {
        public async Task<List<ReverseDnsEntry>> GetReverseDnsEntriesAsync()
        {
            var reverseDnsEntries = await GlobalSettings.apiClient.GetReverseDnsEntriesAsync(GlobalSettings.authInfo);

            return reverseDnsEntries.ToList();
        }
    }
}