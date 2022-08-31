using MyServersWebApp.MyServersApiSimulatorService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyServersWebApp.Data
{
    interface IReverseDnsService
    {
        Task<List<ReverseDnsEntry>> GetReverseDnsEntriesAsync();
    }
}
