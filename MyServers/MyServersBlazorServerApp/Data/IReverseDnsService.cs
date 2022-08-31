using MyServersApiSimulatorService;
using System.Threading.Tasks;

namespace MyServersBlazorServerApp.Data
{
    interface IReverseDnsService
    {
        Task<ReverseDnsEntry[]> GetReverseDnsEntriesAsync();
    }
}
